#pragma checksum "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c23e0927c33ff76b46d651a0fe11ce0a25d9c96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Photos_Index), @"mvc.1.0.view", @"/Views/Photos/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
using Photos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c23e0927c33ff76b46d651a0fe11ce0a25d9c96", @"/Views/Photos/Index.cshtml")]
    public class Views_Photos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AgileEngineImagesResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
  
    ViewData["Title"] = "Photos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Photos</h1>\r\n\r\n<table style=\"text-align:left\" border=\"1\">\r\n    <tr>\r\n        <th>id</th>\r\n        <th>cropped_picture</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 17 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
     foreach (var picture in Model.pictures)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
           Write(picture.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
           Write(picture.cropped_picture);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = picture.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 24 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<table border=\"1\">\r\n    <tr>\r\n");
#nullable restore
#line 28 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
         for (int i = 1; i <= Model.pageCount; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 30 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
           Write(Html.ActionLink(i.ToString(), "Index", new { page = i }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 31 "C:\Users\Administrator\Desktop\PhotoStorage\Views\Photos\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AgileEngineImagesResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
