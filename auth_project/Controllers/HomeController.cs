using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using auth_project.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace auth_project.Controllers
{
    public class HomeController : Controller
    {
        private AuthContext dbContext;
        public HomeController(AuthContext _dbContext)
        {

            dbContext = _dbContext;
        }
        public IActionResult Login()
        {
            
            return View();
        }
       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Userdata obj)
        {

            var dupEmail = dbContext.Userdata.Any(d => d.Email == obj.Email);
            EmailAddressAttribute e = new EmailAddressAttribute();
            if (!e.IsValid(obj.Email))
                return BadRequest("Invalid email address");
            if (dupEmail)
                return BadRequest("Email already exists");
            if (obj.Password.Length < 6)
                return BadRequest("Password less than 6 letters");
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*\W).+$";
            if (!Regex.IsMatch(obj.Password, pattern))
                return BadRequest("Password must contain at least one capital letter, one number and one special character");
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(obj.Password);
            obj.Password = hashedPassword;

            var user = new Userdata
            {
                Email = obj.Email,
                Password = obj.Password,
                Isadmin = obj.Isadmin == true ? true : false
            };
            dbContext.Userdata.Add(user);
            dbContext.SaveChanges();
            return RedirectToAction("Login", "Home");

        }
        [HttpPost]
        public IActionResult Login(Userdata user)
        {
            var storedUser = dbContext.Userdata.FirstOrDefault(d => d.Email == user.Email);

            if (storedUser != null && BCrypt.Net.BCrypt.Verify(user.Password, storedUser.Password))
            {
                // User authentication is successful. Generate a JWT token.
                var securityKey = "This_is_our_security_key"; // Your security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new Claim[]
{
    new Claim(ClaimTypes.Name, user.Email)  ,
    new Claim(ClaimTypes.Role,"Userr")
};

                var token = new JwtSecurityToken(
                    issuer: "smesk.in",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials,
                    claims:claims
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                HttpContext.Session.SetString("JWTToken", tokenString);
        
                    // If the response is successful, redirect to the "Welcome" page
                    return RedirectToAction("Welcome");
                
            }
            else if (storedUser != null)
            {
                // User exists, but the password is incorrect
                return Ok("Invalid password");
            }
            else
            {
                // User does not exist, so prompt them to register
                TempData["Message"] = "User is not registered. Please register first.";
                return RedirectToAction("Register"); // Assuming you have a "Register" action
            }
        }

        public IActionResult Welcome()
        {
            // Retrieve the JWT token from the session
            var tokenString = HttpContext.Session.GetString("JWTToken");
            if (!string.IsNullOrEmpty(tokenString))
            {
                // Decode the JWT token to access its claims
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(tokenString);

                // Retrieve the email claim from the token
                var emailClaim = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);


                // Pass the email to the view
                ViewBag.Email = emailClaim.Value;
               
            }

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
