using System;
using System.Collections.Generic;

namespace auth_project.Models
{
    public partial class Userdata
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Isadmin { get; set; }
    }
}
