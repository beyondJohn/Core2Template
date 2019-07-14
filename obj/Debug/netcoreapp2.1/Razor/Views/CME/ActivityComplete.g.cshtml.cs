#pragma checksum "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5e658d68d1799ac8ad2c37419cc54af3c89b351"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CME_ActivityComplete), @"mvc.1.0.view", @"/Views/CME/ActivityComplete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CME/ActivityComplete.cshtml", typeof(AspNetCore.Views_CME_ActivityComplete))]
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
#line 1 "C:\Users\Alienware\source\repos\Core2Template\Views\_ViewImports.cshtml"
using WebApplication5;

#line default
#line hidden
#line 2 "C:\Users\Alienware\source\repos\Core2Template\Views\_ViewImports.cshtml"
using WebApplication5.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5e658d68d1799ac8ad2c37419cc54af3c89b351", @"/Views/CME/ActivityComplete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_CME_ActivityComplete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("Submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Proceed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/proceed.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
  
    ViewData["Title"] = "ActivityComplete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(119, 31, true);
            WriteLiteral("\r\n<h2>ActivityComplete</h2>\r\n\r\n");
            EndContext();
#line 10 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
 using (Html.BeginForm(null, null, FormMethod.Post, new { name = "myForm", id = "myForm" }))
{

#line default
#line hidden
            BeginContext(247, 74, true);
            WriteLiteral("    <br />\r\n        <div style=\"padding-left:15px; padding-right:15px;\">\r\n");
            EndContext();
#line 14 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
              
                //@Html.Raw("An email containing a link to your certificate for this activity has been sent to " + @email + ".<br /><br />"
                int caseID = int.Parse(ViewContext.RouteData.Values["id"].ToString());
                int userID = int.Parse(ViewContext.HttpContext.Request.Cookies["uID"].ToString());
                float grade = Model.getGrade(userID, caseID);
                string email = Model.getParticipantData(userID).Select(x => x.Email).FirstOrDefault();
                string title = Model.getActivityData(caseID).Select(x => x.Case_Title).FirstOrDefault();
            

#line default
#line hidden
            BeginContext(954, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(967, 24, false);
#line 22 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
       Write(Html.Raw("<br /><br />"));

#line default
#line hidden
            EndContext();
            BeginContext(991, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1006, 134, false);
#line 23 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
       Write(Html.Raw("You have successfully completed the activity titled <b>\"" + @title + "\"</b> with a grade of " + @grade + "%.<br /><br />"));

#line default
#line hidden
            EndContext();
            BeginContext(1140, 131, true);
            WriteLiteral("\r\n\r\n            Proceed to view/print your certificate now.<br /><br />Thank you for participating in this activity!\"\r\n            ");
            EndContext();
            BeginContext(1272, 30, false);
#line 26 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
       Write(Html.Raw("<br /><br /><br />"));

#line default
#line hidden
            EndContext();
            BeginContext(1302, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1316, 113, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c860709c92845febebefca0670f8db3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1429, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1444, 24, false);
#line 28 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
       Write(Html.Raw("<br /><br />"));

#line default
#line hidden
            EndContext();
            BeginContext(1468, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 30 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\ActivityComplete.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
