#pragma checksum "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a71507ab6d8756031d1d585eacef377f6f6847f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CME_Activity), @"mvc.1.0.view", @"/Views/CME/Activity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CME/Activity.cshtml", typeof(AspNetCore.Views_CME_Activity))]
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
#line 1 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
using WebApplication5.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a71507ab6d8756031d1d585eacef377f6f6847f3", @"/Views/CME/Activity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_CME_Activity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Activity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CME", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
  
    ViewData["Title"] = "Activity";

#line default
#line hidden
            BeginContext(98, 23, true);
            WriteLiteral("\r\n<h2>Activity</h2>\r\n\r\n");
            EndContext();
            BeginContext(121, 2572, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "867b45b22d9d4c8595945f0a87e8f28c", async() => {
                BeginContext(210, 58, true);
                WriteLiteral("\r\n    <div style=\"padding:15px; padding-bottom:75px;\">\r\n\r\n");
                EndContext();
#line 14 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
          
            string CaseID = Model.CaseId;
            int questionNumber = 0;
            ///CME/Activity/773?q=0
        

#line default
#line hidden
                BeginContext(408, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 20 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
         if (ViewContext.RouteData.Values["q"] != null)
        {
            questionNumber = int.Parse(ViewContext.RouteData.Values["q"].ToString());
        }

#line default
#line hidden
                BeginContext(576, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 24 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
         if (ViewContext.RouteData.Values["id"] != null)
        {
            CaseID = ViewContext.RouteData.Values["id"].ToString();
        }

#line default
#line hidden
                BeginContext(725, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 28 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
          
            Model.CaseId = CaseID;
            string openingText = "";
            string questionText = "";

#line default
#line hidden
                BeginContext(851, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 32 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
         for (int i = 0; i < Model.getActivityQuestions(CaseID).Count(); i++)
        {
            Model.QuestionNumber = i.ToString();
            if (i == questionNumber)
            {
                openingText = Model.getActivityQuestions(CaseID)
                    .Select(m => m.Opening_Text)
                    .Skip(i)
                    .FirstOrDefault()
                    .ToString();
                var answerCount = Model.Answers.Count;
                

#line default
#line hidden
                BeginContext(1336, 21, false);
#line 43 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
           Write(Html.Raw(openingText));

#line default
#line hidden
                EndContext();
#line 43 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                      ;

#line default
#line hidden
                BeginContext(1360, 24, true);
                WriteLiteral("                <br />\r\n");
                EndContext();
#line 45 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                questionText = Model.getActivityQuestions(CaseID).Select(m => m.question_text).Skip(i).FirstOrDefault().ToString();
                

#line default
#line hidden
                BeginContext(1534, 22, false);
#line 46 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
           Write(Html.Raw(questionText));

#line default
#line hidden
                EndContext();
#line 46 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                       ;

#line default
#line hidden
                BeginContext(1559, 24, true);
                WriteLiteral("                <br />\r\n");
                EndContext();
#line 48 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                foreach (var answer in Model.Answers)
                {
                    

#line default
#line hidden
                BeginContext(1678, 98, false);
#line 50 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
               Write(Html.RadioButtonFor(m => m.SelectedAnswer, answer.Answer_Id, new { onchange = "selected(this);" }));

#line default
#line hidden
                EndContext();
                BeginContext(1778, 18, false);
#line 50 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                                                                                                   Write(answer.Answer_Text);

#line default
#line hidden
                EndContext();
                BeginContext(1798, 28, true);
                WriteLiteral("                    <br />\r\n");
                EndContext();
#line 52 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                    string breakMe = "";
                }
            }
        }

#line default
#line hidden
                BeginContext(1913, 8, true);
                WriteLiteral("        ");
                EndContext();
#line 56 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
          
            var check = openingText;
            if (Model.Answers.Count == 0)
            {
                if (questionText == "<font color=\"white\">.</font>")
                {
                    if (!ViewContext.HttpContext.Request.Query.Where(x => x.Key == "src" && x.Value == "mycme").Any())
                    {
                        

#line default
#line hidden
                BeginContext(2279, 130, false);
#line 64 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                   Write(Html.Raw("<a href='/CME/PostTest/" + CaseID + "'><img src='../../../Images/proceed.jpg' style='width:200px; border:none;' /></a>"));

#line default
#line hidden
                EndContext();
#line 64 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                                                                                                                                           
                    }

                }

            }

        

#line default
#line hidden
                BeginContext(2485, 201, true);
                WriteLiteral("        <br />\r\n        <div id=\"divResponse\">\r\n        </div>\r\n        <div id=\"divArrow\" style=\"display:block; margin:25px 0;\">\r\n        </div>\r\n        <div id=\"floor\">\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2693, 436, true);
            WriteLiteral(@"
<script>
    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
    var questionCount = ");
            EndContext();
            BeginContext(3130, 81, false);
#line 91 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                   Write(Model.getActivityQuestions(ViewContext.RouteData.Values["id"].ToString()).Count());

#line default
#line hidden
            EndContext();
            BeginContext(3211, 1183, true);
            WriteLiteral(@";
    var arrowDiv = document.getElementById(""divArrow"");
    console.log(""questionCount: "", questionCount);
    var responseJson = [];
    function selected(btn) {
        if (responseJson.length > 0) {
            var url = window.location.href;
            var src = getParameterByName(""src"", url);
            console.log(""src: "" + src);
            for (var i = 0; i < responseJson.length; i++) {
                var responseObj = JSON.parse(JSON.stringify(responseJson[i]));
                if (Object.keys(responseObj)[0] === btn.value) {
                    var responseDiv = document.getElementById(""divResponse"");
                    responseDiv.innerHTML = responseObj[btn.value][""explain""];
                    if (responseObj[btn.value][""correct""] === ""1"") {
                        responseDiv.style = ""border:solid 1px #037614; background-color:#0bd82a; padding:20px;"";
                    }
                    else {
                        responseDiv.style = ""border:solid 1px #f00; back");
            WriteLiteral("ground-color:#e48989; padding:20px;\"\r\n                    }\r\n                    if (responseObj[btn.value][\"correct\"] === \"1\") {\r\n                        if (");
            EndContext();
            BeginContext(4395, 44, false);
#line 112 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                       Write(ViewContext.RouteData.Values["q"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(4439, 182, true);
            WriteLiteral(" < questionCount - 1) {\r\n                            if (src != \'mycme\') {\r\n                                arrowDiv.innerHTML =\r\n                            \'<a href=\"/CME/Activity/");
            EndContext();
            BeginContext(4622, 45, false);
#line 115 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                               Write(ViewContext.RouteData.Values["id"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(4667, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(4670, 57, false);
#line 115 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                                                                               Write(int.Parse(ViewContext.RouteData.Values["q"].ToString())+1);

#line default
#line hidden
            EndContext();
            BeginContext(4728, 258, true);
            WriteLiteral(@"""><img src=""../../../Images/proceed.jpg"" style=""width:200px; border:none;"" /></a>';
                            }
                            else {
                                arrowDiv.innerHTML =
                            '<a href=""/CME/Activity/");
            EndContext();
            BeginContext(4987, 45, false);
#line 119 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                               Write(ViewContext.RouteData.Values["id"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(5032, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(5035, 57, false);
#line 119 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                                                                               Write(int.Parse(ViewContext.RouteData.Values["q"].ToString())+1);

#line default
#line hidden
            EndContext();
            BeginContext(5093, 471, true);
            WriteLiteral(@"?src=mycme""><img src=""../../../Images/proceed.jpg"" style=""width:200px; border:none;"" /></a>';
                            }
                        }
                        else {
                            if (src == 'mycme') {
                                arrowDiv.innerHTML = """";
                            }
                            else {
                                arrowDiv.innerHTML =
                                '<a href=""/CME/PostTest/");
            EndContext();
            BeginContext(5565, 45, false);
#line 128 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
                                                   Write(ViewContext.RouteData.Values["id"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(5610, 1162, true);
            WriteLiteral(@"""><img src=""../../../Images/proceed.jpg"" style=""width:200px; border:none;"" /></a>';
                            }
                            
                        }
                    }
                    else {
                        arrowDiv.innerHTML = """";
                    }
                    window.location.href = ""#floor"";
                }
            }
        }

    }
    function loadDoc() {
        var url = window.location.href;
        var src = getParameterByName(""src"", url);
        console.log(""src: "" + src);
        if (src == 'mycme') {
            arrowDiv.innerHTML = """";
        }
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                responseJson = this.responseText;

                // remove (hidden)carriage return & new line characters
                responseJson = responseJson.replace(/\r?\n|\r/g, """");

                responseJson ");
            WriteLiteral("= JSON.parse(responseJson);\r\n            }\r\n        };\r\n        xhttp.open(\"GET\", window.location.origin + \"/api/answers/\"\r\n            + ");
            EndContext();
            BeginContext(6773, 56, false);
#line 161 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
         Write(int.Parse(ViewContext.RouteData.Values["id"].ToString()));

#line default
#line hidden
            EndContext();
            BeginContext(6829, 34, true);
            WriteLiteral("\r\n            +\"/\"\r\n            + ");
            EndContext();
            BeginContext(6864, 55, false);
#line 163 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Activity.cshtml"
         Write(int.Parse(ViewContext.RouteData.Values["q"].ToString()));

#line default
#line hidden
            EndContext();
            BeginContext(6919, 151, true);
            WriteLiteral(", true);\r\n        xhttp.setRequestHeader(\"Content-type\", \"application/x-www-form-urlencoded\");\r\n        xhttp.send();\r\n    }\r\n    loadDoc();\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
