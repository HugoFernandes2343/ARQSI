#pragma checksum "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99347810e90ff8e2e41cca7c2fc458e7b286eb68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dimensions_List), @"mvc.1.0.view", @"/Views/Dimensions/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dimensions/List.cshtml", typeof(AspNetCore.Views_Dimensions_List))]
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
#line 1 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\_ViewImports.cshtml"
using SIC;

#line default
#line hidden
#line 2 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\_ViewImports.cshtml"
using SIC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99347810e90ff8e2e41cca7c2fc458e7b286eb68", @"/Views/Dimensions/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08814bd193e5e2070159aff3d39d3364083c7071", @"/Views/_ViewImports.cshtml")]
    public class Views_Dimensions_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SIC.Models.Dimensions>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
            BeginContext(85, 28, true);
            WriteLiteral("\r\n<h2>List</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(113, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7d49da6dbd94f199616e19f78726b60", async() => {
                BeginContext(136, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(150, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(243, 48, false);
#line 16 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayNameFor(model => model.DimensionsId));

#line default
#line hidden
            EndContext();
            BeginContext(291, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(347, 42, false);
#line 19 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayNameFor(model => model.height));

#line default
#line hidden
            EndContext();
            BeginContext(389, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(445, 41, false);
#line 22 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayNameFor(model => model.width));

#line default
#line hidden
            EndContext();
            BeginContext(486, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(542, 41, false);
#line 25 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayNameFor(model => model.depth));

#line default
#line hidden
            EndContext();
            BeginContext(583, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(701, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(750, 47, false);
#line 34 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.DimensionsId));

#line default
#line hidden
            EndContext();
            BeginContext(797, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(853, 41, false);
#line 37 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.height));

#line default
#line hidden
            EndContext();
            BeginContext(894, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(950, 40, false);
#line 40 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.width));

#line default
#line hidden
            EndContext();
            BeginContext(990, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1046, 40, false);
#line 43 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.depth));

#line default
#line hidden
            EndContext();
            BeginContext(1086, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1142, 65, false);
#line 46 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1207, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1228, 71, false);
#line 47 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1320, 69, false);
#line 48 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1389, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 51 "E:\Faculdade\Old Repositories\ARQSI\SIC\Views\Dimensions\List.cshtml"
}

#line default
#line hidden
            BeginContext(1428, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SIC.Models.Dimensions>> Html { get; private set; }
    }
}
#pragma warning restore 1591
