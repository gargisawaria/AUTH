#pragma checksum "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\Home\Welcome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "929f749f7bb09ae6c2828353e0deddcd9f3cfca1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Welcome), @"mvc.1.0.view", @"/Views/Home/Welcome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Welcome.cshtml", typeof(AspNetCore.Views_Home_Welcome))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\_ViewImports.cshtml"
using auth_project;

#line default
#line hidden
#line 2 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\_ViewImports.cshtml"
using auth_project.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"929f749f7bb09ae6c2828353e0deddcd9f3cfca1", @"/Views/Home/Welcome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"789917202d9b30b7064b7a686cb4f4d0511457d8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Welcome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\Home\Welcome.cshtml"
  
    ViewData["Title"] = "Welcome";

#line default
#line hidden
#line 5 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\Home\Welcome.cshtml"
 if (@ViewBag.Email == null)
{

#line default
#line hidden
            BeginContext(78, 34, true);
            WriteLiteral("    <h1>User Not Authorised</h1>\r\n");
            EndContext();
#line 8 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\Home\Welcome.cshtml"

}
else {

#line default
#line hidden
            BeginContext(125, 12, true);
            WriteLiteral("<h2>Welcome ");
            EndContext();
            BeginContext(138, 13, false);
#line 11 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\Home\Welcome.cshtml"
       Write(ViewBag.Email);

#line default
#line hidden
            EndContext();
            BeginContext(151, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 12 "C:\Users\GargiSawaria\source\repos\auth_project\auth_project\Views\Home\Welcome.cshtml"

}

#line default
#line hidden
            BeginContext(163, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
