#pragma checksum "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "678faf7ecc3b37b39570e3ab181effa4b0918f23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CME_Evaluation), @"mvc.1.0.view", @"/Views/CME/Evaluation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CME/Evaluation.cshtml", typeof(AspNetCore.Views_CME_Evaluation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"678faf7ecc3b37b39570e3ab181effa4b0918f23", @"/Views/CME/Evaluation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_CME_Evaluation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication5.Models.TestModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/proceed.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
  
    ViewData["Title"] = "Evaluation";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(136, 79, true);
            WriteLiteral("\r\n<h2>Evaluation</h2>\r\n\r\n<div style=\"padding-left:15px; padding-right:15px;\">\r\n");
            EndContext();
#line 11 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
     using (Html.BeginForm(null, null, FormMethod.Post, new { name = "myForm", id = "myForm", style="margin-bottom: 100px;" }))
    {
        int CaseID = 0;
        if (ViewContext.RouteData.Values["id"] != null)
        {
            CaseID = int.Parse(ViewContext.RouteData.Values["id"].ToString());
        }
        int selectedIfYesAdder = 0;
        int SelectedEvaluationAnswersAdder = 0;
        int selectedTextOnlyAdder = 0;
        for (int i = 0; i < Model.getEvalQuestions(CaseID).Count(); i++)
        {
            string questionText = Model.getEvalQuestions(CaseID).Select(m => m.question_text).Skip(i).FirstOrDefault().ToString();
            int questionID = int.Parse(Model.getEvalQuestions(CaseID).Select(m => m.Question_Id).Skip(i).FirstOrDefault().ToString());
            

#line default
#line hidden
            BeginContext(1027, 22, false);
#line 25 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
       Write(Html.Raw(questionText));

#line default
#line hidden
            EndContext();
#line 25 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                   ;

#line default
#line hidden
            BeginContext(1052, 20, true);
            WriteLiteral("            <br />\r\n");
            EndContext();
#line 27 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
            int questionType = Model.getQuestionType(questionID);
            if (questionType == 6)//Confident
            {
                //string[] excellents = new string[] { "Not confident at all", "Not very confident", "Neutral", "Very confident", "Extremely confident" };
                for (int ii = 4; ii >= 0; ii--)
                {
                    

#line default
#line hidden
            BeginContext(1446, 89, false);
#line 33 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.RadioButtonFor(m => m.SelectedEvaluationAnswers[SelectedEvaluationAnswersAdder], ii));

#line default
#line hidden
            EndContext();
            BeginContext(1559, 19, false);
#line 34 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                Write((ii + 1).ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1602, 24, false);
#line 35 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.Raw("&nbsp;&nbsp;"));

#line default
#line hidden
            EndContext();
#line 35 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                             
                }
                

#line default
#line hidden
            BeginContext(1664, 177, false);
#line 37 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
           Write(Html.Raw("<br /><span style='color:Gray;font-size:Small;'>5 = Extremely Confident | 4 = Very Confident | 3 = Neutral | 2 = Not Very Confident | 1 = Not Confident At All</span>"));

#line default
#line hidden
            EndContext();
#line 37 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                                                                                                                                                                                  ;
                SelectedEvaluationAnswersAdder++;
            }
            if (questionType == 7)//strongly agree
            {
                //string[] stronglies = new string[] { "Strongly Disagree", "Disagree", "Neutral", "Agree", "Strongly Agree" };
                for (int ii = 4; ii >= 0; ii--)
                {
                    

#line default
#line hidden
            BeginContext(2195, 89, false);
#line 45 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.RadioButtonFor(m => m.SelectedEvaluationAnswers[SelectedEvaluationAnswersAdder], ii));

#line default
#line hidden
            EndContext();
            BeginContext(2308, 19, false);
#line 46 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                Write((ii + 1).ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2351, 24, false);
#line 47 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.Raw("&nbsp;&nbsp;"));

#line default
#line hidden
            EndContext();
#line 47 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                             
                }
                

#line default
#line hidden
            BeginContext(2413, 150, false);
#line 49 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
           Write(Html.Raw("<br /><span style='color:Gray;font-size:Small;'>5 = Strongly Agree | 4 = Agree | 3 = Neutral | 2 = Disagree | 1 = Strongly Disagree</span>"));

#line default
#line hidden
            EndContext();
#line 49 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                                                                                                                                                       ;
                SelectedEvaluationAnswersAdder++;
            }

            if (questionType == 8)//If Yes '1 = yes'
            {
                string[] ifYes = new string[] { "No", "Yes" };
                for (int ii = 0; ii < 2; ii++)
                {
                    

#line default
#line hidden
            BeginContext(2855, 72, false);
#line 58 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.RadioButtonFor(m => m.SelectedIfYesAnswers[selectedIfYesAdder], ii));

#line default
#line hidden
            EndContext();
            BeginContext(2950, 9, false);
#line 59 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(ifYes[ii]);

#line default
#line hidden
            EndContext();
#line 59 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                              
                    if (ii == 1)
                    {
                        

#line default
#line hidden
            BeginContext(3043, 38, false);
#line 62 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                   Write(Html.Raw(" (If yes, please explain.)"));

#line default
#line hidden
            EndContext();
#line 62 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                                               
                    }

#line default
#line hidden
            BeginContext(3106, 28, true);
            WriteLiteral("                    <br />\r\n");
            EndContext();
#line 65 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                }
                

#line default
#line hidden
            BeginContext(3170, 46, false);
#line 66 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
           Write(Html.TextAreaFor(t => t.ifYesText, questionID));

#line default
#line hidden
            EndContext();
#line 66 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                                               
                selectedIfYesAdder++;
            }
            if (questionType == 10)//Excellent
            {
                //string[] excellents = new string[] { "Strongly Disagree", "Poor", "Fair", "Very Good", "Excellent" };
                for (int ii = 4; ii >= 0; ii--)
                {
                    

#line default
#line hidden
            BeginContext(3545, 89, false);
#line 74 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.RadioButtonFor(m => m.SelectedEvaluationAnswers[SelectedEvaluationAnswersAdder], ii));

#line default
#line hidden
            EndContext();
            BeginContext(3658, 19, false);
#line 75 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                Write((ii + 1).ToString());

#line default
#line hidden
            EndContext();
            BeginContext(3701, 24, false);
#line 76 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.Raw("&nbsp;&nbsp;"));

#line default
#line hidden
            EndContext();
#line 76 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                             
                }
                

#line default
#line hidden
            BeginContext(3763, 134, false);
#line 78 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
           Write(Html.Raw("<br /><span style='color:Gray;font-size:Small;'>5 = Excellent | 4 = Very Good | 3 = Fair | 2 = Poor | 1 = Very Poor</span>"));

#line default
#line hidden
            EndContext();
#line 78 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                                                                                                                                       ;
                SelectedEvaluationAnswersAdder++;
            }
            if (questionType == 22)//Always Often
            {
                string[] excellents = new string[] { "Never", "Sometimes", "Often", "Always" };
                for (int ii = 0; ii < 4; ii++)
                {
                    

#line default
#line hidden
            BeginContext(4217, 89, false);
#line 86 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(Html.RadioButtonFor(m => m.SelectedEvaluationAnswers[SelectedEvaluationAnswersAdder], ii));

#line default
#line hidden
            EndContext();
            BeginContext(4329, 14, false);
#line 87 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
               Write(excellents[ii]);

#line default
#line hidden
            EndContext();
            BeginContext(4345, 28, true);
            WriteLiteral("                    <br />\r\n");
            EndContext();
#line 89 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                }
                SelectedEvaluationAnswersAdder++;
            }
            if (questionType == 14)//Text Only
            {
                

#line default
#line hidden
            BeginContext(4538, 68, false);
#line 94 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
           Write(Html.TextAreaFor(t => t.textOnly[selectedTextOnlyAdder], questionID));

#line default
#line hidden
            EndContext();
#line 94 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                                                                                     
                selectedTextOnlyAdder++;
            }
            

#line default
#line hidden
            BeginContext(4678, 18, false);
#line 97 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
       Write(Html.Raw("<br />"));

#line default
#line hidden
            EndContext();
#line 97 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
                               ;
            

#line default
#line hidden
            BeginContext(5035, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 106 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
        }

#line default
#line hidden
            BeginContext(5054, 1021, true);
            WriteLiteral(@"        <script type=""text/javascript"">
                function checkRadios() {
                    var names = {};
                    $('input:radio').each(function () { // find unique names
                        names[$(this).attr('name')] = true;
                    });
                    var count = 0;
                    $.each(names, function () { // then count them
                        count++;
                    });
                    if ($('input:radio:checked').length == count) {
                        // all questions answered
                        //alert($('input:radio:checked').contents) //uncomment to view underlying javascript
                        $(""#myForm"").submit();
                    }
                    else {
                        alert(""Please answer all questions before proceeding. Thank you!"");
                    }
                }
        </script>
        <br />
        <div onclick=""checkRadios()"" style=""cursor:pointer;"">
            ");
            EndContext();
            BeginContext(6075, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "66c88c5a197740b78708261ff0259f96", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6130, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 131 "C:\Users\Alienware\source\repos\Core2Template\Views\CME\Evaluation.cshtml"
    }

#line default
#line hidden
            BeginContext(6155, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication5.Models.TestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
