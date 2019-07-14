#pragma checksum "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f599577ef22ee69ed587e377622e4902e29ae9fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Account), @"mvc.1.0.view", @"/Views/User/Account.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Account.cshtml", typeof(AspNetCore.Views_User_Account))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f599577ef22ee69ed587e377622e4902e29ae9fd", @"/Views/User/Account.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Account : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication5.Models.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
  
    ViewData["Title"] = "Account";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(133, 34, true);
            WriteLiteral("\r\n    <h2>Account History</h2>\r\n\r\n");
            EndContext();
#line 10 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
 using (Html.BeginForm())
 {

#line default
#line hidden
            BeginContext(198, 53, true);
            WriteLiteral("<div style=\"margin-bottom: 100px;\">\r\n        <br />\r\n");
            EndContext();
#line 14 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
          int userID =  Model.UserId;

#line default
#line hidden
            BeginContext(291, 82, true);
            WriteLiteral("        <table style=\"width:900px; \">\r\n            <tr style=\"font-weight:700;\">\r\n");
            EndContext();
#line 17 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                  int countPreTests = Model.accountPrePostHistory(userID, 1).Count();
                       if (countPreTests != 0)
                       {
                    

#line default
#line hidden
            BeginContext(555, 156, false);
#line 20 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
               Write(Html.Raw("<td width='55%'>Activity Title</td><td width='15%'>Progress</td><td width='10%' style='text-align:center;'>Credits</td><td width='40%'>View</td>"));

#line default
#line hidden
            EndContext();
#line 20 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                                                                                                 ;
                       }
                       else
                       {
                    

#line default
#line hidden
            BeginContext(816, 65, false);
#line 24 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
               Write(Html.Raw("<td>You do not have any account activity history</td>"));

#line default
#line hidden
            EndContext();
#line 24 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                      ;
                       }
                

#line default
#line hidden
            BeginContext(929, 21, true);
            WriteLiteral("            </tr>\r\n\r\n");
            EndContext();
#line 29 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
              
               foreach(var startedActivity in Model.accountPrePostHistory(userID, 1))//Pretest Complete
               {
                   int caseID = startedActivity.Value;
                

#line default
#line hidden
            BeginContext(1162, 102, false);
#line 33 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<tr><td>" + Model.activityData(caseID).Select(x => x.Case_Title).FirstOrDefault() + "</td>"));

#line default
#line hidden
            EndContext();
#line 33 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                                       ;
                   int? countPostTests = Model.countPostAttempts(caseID, userID);
                   if (countPostTests != 0)//post test taken
                   {
                       int checkPassed = Model.earnedList(caseID, userID).Count();
                       if (checkPassed != 0)//post test passed
                       {

                           int checkEval = Model.accountEvaluationHistory(userID, caseID).Count();
                           if (checkEval != 0)//eval taken
                           {
                               var checkEarnedForClaimed = Model.earnedList(caseID, userID);
                               {
                                   if (checkEarnedForClaimed != null)
                                   {
                                       foreach (var checkClaimed in checkEarnedForClaimed)
                                       {
                                           var claimed = checkClaimed.Claimed;
                                           if (claimed != null)//credit has been claimed
                                           {
                

#line default
#line hidden
            BeginContext(2404, 38, false);
#line 53 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td>Activity complete</td>"));

#line default
#line hidden
            EndContext();
#line 53 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                       ;
                

#line default
#line hidden
            BeginContext(2462, 75, false);
#line 54 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td style='text-align:center;'>"+ checkClaimed.Claimed + "</td>"));

#line default
#line hidden
            EndContext();
#line 54 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                            ;
                

#line default
#line hidden
            BeginContext(2557, 91, false);
#line 55 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td><a href='../CME/certificate/" + caseID + "' >View certificate</a></td></tr>"));

#line default
#line hidden
            EndContext();
#line 55 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                            ;
                                           }
                                           else//no credit claimed
                                           {
                

#line default
#line hidden
            BeginContext(2828, 40, false);
#line 59 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td>Evaluation complete</td>"));

#line default
#line hidden
            EndContext();
#line 59 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                         ;
                

#line default
#line hidden
            BeginContext(2888, 49, false);
#line 60 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td style='text-align:center;'>0</td>"));

#line default
#line hidden
            EndContext();
#line 60 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                  ;
                

#line default
#line hidden
            BeginContext(2957, 87, false);
#line 61 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td><a href='../CME/ClaimCredit/" + caseID + "' >Claim credit</a></td></tr>"));

#line default
#line hidden
            EndContext();
#line 61 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                        ;
                                           }
                                       }
                                   }
                               }
                           }
                           else//no eval taken
                           {
                

#line default
#line hidden
            BeginContext(3332, 39, false);
#line 69 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td>Post-test complete</td>"));

#line default
#line hidden
            EndContext();
#line 69 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                        ;
                

#line default
#line hidden
            BeginContext(3391, 49, false);
#line 70 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td style='text-align:center;'>0</td>"));

#line default
#line hidden
            EndContext();
#line 70 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                  ;
                

#line default
#line hidden
            BeginContext(3460, 93, false);
#line 71 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td><a href='../CME/Evaluation/" + caseID + "' >Complete evaluation</a></td></tr>"));

#line default
#line hidden
            EndContext();
#line 71 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                              ;
                           }
                       }
                       else//post test Failed
                       {
                           int checkAttempts = Model.countPostAttempts(caseID, userID);
                           if (checkAttempts < 3)
                           {
                

#line default
#line hidden
            BeginContext(3872, 80, false);
#line 79 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td>Post-test <br />(" + checkAttempts.ToString() + " attempts)</td>"));

#line default
#line hidden
            EndContext();
#line 79 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                 ;
                

#line default
#line hidden
            BeginContext(3972, 49, false);
#line 80 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td style='text-align:center;'>0</td>"));

#line default
#line hidden
            EndContext();
#line 80 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                  ;
                

#line default
#line hidden
            BeginContext(4041, 87, false);
#line 81 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td><a href='../CME/PostTest/"+ caseID + "' >Retake Post-Test</a></td></tr>"));

#line default
#line hidden
            EndContext();
#line 81 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                        ;
                           }
                           else
                           {
                

#line default
#line hidden
            BeginContext(4241, 80, false);
#line 85 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td>Post-test <br />(" + checkAttempts.ToString() + " attempts)</td>"));

#line default
#line hidden
            EndContext();
#line 85 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                 ;
                

#line default
#line hidden
            BeginContext(4341, 49, false);
#line 86 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td style='text-align:center;'>0</td>"));

#line default
#line hidden
            EndContext();
#line 86 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                  ;
                

#line default
#line hidden
            BeginContext(4410, 112, false);
#line 87 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td><a href='../CME/Activity/" + caseID + "/0' >Attempts Exceeded - Return to activity</a></td></tr>"));

#line default
#line hidden
            EndContext();
#line 87 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                                                 ;
                           }
                       }
                   }
                   else//no post test taken
                   {
                

#line default
#line hidden
            BeginContext(4687, 38, false);
#line 93 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td>Pre-test complete</td>"));

#line default
#line hidden
            EndContext();
#line 93 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                       ;
                

#line default
#line hidden
            BeginContext(4745, 49, false);
#line 94 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td style='text-align:center;'>0</td>"));

#line default
#line hidden
            EndContext();
#line 94 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                  ;
                

#line default
#line hidden
            BeginContext(4814, 92, false);
#line 95 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
           Write(Html.Raw("<td><a href='../CME/Activity/" + caseID + "/0' >Return to activity</a></td></tr>"));

#line default
#line hidden
            EndContext();
#line 95 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                                                                                                             ;
                   }
               }
            

#line default
#line hidden
            BeginContext(4964, 75, true);
            WriteLiteral("        </table>\r\n        <br />\r\n</div>\r\n<br />\r\n<span style=\"color:red;\">");
            EndContext();
            BeginContext(5040, 46, false);
#line 103 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"
                    Write(Html.ValidationSummary(true, "Update Failed."));

#line default
#line hidden
            EndContext();
            BeginContext(5086, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 104 "C:\Users\Alienware\source\repos\Core2Template\Views\User\Account.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication5.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
