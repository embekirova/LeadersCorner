#pragma checksum "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64ed46af389a175140028ea15c2a08173b9a483c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CommentPartial), @"mvc.1.0.view", @"/Views/Shared/_CommentPartial.cshtml")]
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
#line 1 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\_ViewImports.cshtml"
using LeadersCorner.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\_ViewImports.cshtml"
using LeadersCorner.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\_ViewImports.cshtml"
using LeadersCorner.Web.ViewModels.Article;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
using LeadersCorner.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
using LeadersCorner.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64ed46af389a175140028ea15c2a08173b9a483c", @"/Views/Shared/_CommentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f5187377037dad09f259201810edb9a68ed6fe9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CommentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LeadersCorner.Web.ViewModels.Article.CurrentArticleViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
 if (Model.Comments.Any())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
     foreach (var comment in Model.Comments)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dd> ");
#nullable restore
#line 11 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
        Write(Html.DisplayFor(x => comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 12 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <h6 class=\"heading-margin text-center\">Be the first to comment this article!</h6>\r\n    </div>\r\n");
#nullable restore
#line 19 "C:\Users\Lenovo\Desktop\LeadersCorner\Web\LeadersCorner.Web\Views\Shared\_CommentPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LeadersCorner.Web.ViewModels.Article.CurrentArticleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
