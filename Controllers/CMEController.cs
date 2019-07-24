using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using static WebApplication5.Models.ModelDbContext;

namespace WebApplication5.Controllers
{
    public class CMEController : Controller
    {
        private readonly IOptions<AppSettings> connections;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CMEController(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appsettings)
        {
            connections = appsettings;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        //Begin PreTest
        public ActionResult PreTest(string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "PreTest", option);
            int myId = int.Parse(id.ToString());
            //read cookie from IHttpContextAccessor  
            //
            //_httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
            //read cookie from Request object  
            string caseId = id;
            string userId = Request.Cookies["uID"];

            //if (!userId.Any())
            //    return RedirectToAction("Login", "User");

            //if (!caseId.Any())
            //    return RedirectToAction("Index", "Home");

            //
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            int checkTaken = 0;
            using (var db = new ModelDbContext())
            {
                var cId = int.Parse(id);
                var uId = int.Parse(userId);
                checkTaken = (db.DataCollectionTable
                    .Where(x => x.Case_Id == cId
                        && x.User_Id == uId
                        && x.Pre_Test == 1)
                    .Select(x => x.Answer_Id))
                    .Count();
            }
            //
            if (checkTaken != 0)
            {
                return RedirectToAction("Activity", "CME", new { id = caseId, q = 0 });
            }
            var questionsList = new TestModel(_httpContextAccessor).getActivityQuestions(caseId);
            var testModel = new TestModel(_httpContextAccessor);
            testModel.CaseId = caseId;
            return View(testModel);

        }
        [HttpPost]
        public ActionResult PreTest(TestModel myModel, IFormCollection form, string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "PreTest", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            TestModel myTestModel = myModel;
            int userID = int.Parse(Request.Cookies["uID"]);
            int caseID = int.Parse(id);
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            using (var db = new ModelDbContext())
            {
                int checkTaken = (from c in db.DataCollectionTable
                                  where c.Case_Id == caseID
                                  && c.User_Id == userID
                                  && c.Pre_Test == 1
                                  select c.Answer_Id).Count();
                if (checkTaken == 0)
                {
                    int? myAttempt = (from a in db.AttemptTable
                                      where a.Case_Id == caseID
                                      && a.User_Id == userID
                                      && a.Pre_Test == 0
                                      select a.Attempt_Id).Count();
                    Attempt_Table newAttempt = new Attempt_Table()
                    {
                        Attempt = 1,
                        User_Id = userID,
                        Case_Id = caseID,
                        Date_Time = DateTime.Now,
                        Pre_Test = 1
                    };
                    db.Add(newAttempt);
                    db.SaveChanges();
                    foreach (var answerID in myTestModel.SelectedPreTestAnswer)
                    {
                        int questionID = myTestModel.getQuestionID(answerID);

                        Data_Collection_Table collectAnswer = new Data_Collection_Table
                        {
                            User_Id = userID,
                            Answer_Id = answerID,
                            Pre_Test = 1,
                            Attempt = null,
                            Question_Id = questionID,
                            Case_Id = caseID
                        };
                        db.Add(collectAnswer);
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Activity", "CME", new { id = caseID, q = 0 });
            }
        }
        //End PreTest
        //Begin Activity
        [HttpGet]
        public ActionResult Activity(string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "Activity", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            TestModel myTestModel = new TestModel();
            myTestModel.CaseId = id;
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult Activity(TestModel myModel, string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "Activity", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            return View(myModel);
        }
        //End Activity

        //Begin Post-Test
        [HttpGet]
        public ActionResult PostTest(string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "PostTest", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account" , "Identity", new { id = "Login" });
            }
            int userId = 0;
            TestModel myTestModel = new TestModel();
            using (var db = new ModelDbContext())
            {
                var user = db.Users.Where(x => x.Email == User.Identity.Name);
                if (user.Any())
                {
                    userId = user.Single().User_Id;
                    Response.Cookies.Append("uID", userId.ToString(), option);
                    Response.Cookies.Append("uN", user.Single().First_Name, option);
                }
                //else
                //{
                    
                //    // Create user account if necessary
                //    var newUserId = myTestModel.CrossLogin(User.Identity.Name);
                //    Response.Cookies.Append("uID", newUserId.ToString(), option);
                //}

            }
            int userID = userId;// int.Parse(Request.Cookies["uID"].Value.ToString());
            int caseID = int.Parse(id);
            //if (Request.QueryString["id"] != null)
            //{
            //    caseID = int.Parse(Request.QueryString["id"].ToString());
            //}
            bool IsEarned = myTestModel.IsEarned(userID, caseID);
            if (IsEarned == true)
            {
                return RedirectToAction("Results", "CME", new { id = caseID });
            }
            int? attempt = myTestModel.getAttemptCount(userID, caseID);
            if (attempt != null)
            {
                attempt = attempt++;
            }
            else
            {
                attempt = 1;
            }
            if (attempt >= 3)
            {
                return RedirectToAction("Results", "CMETest", new { id = caseID });
            }
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult PostTest(TestModel myModel, string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "PostTest", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            TestModel myTestModel = myModel;
            int userID = int.Parse(Request.Cookies["uID"]);
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            int? attempt = myTestModel.getAttemptCount(userID, caseID);
            if (attempt != null)
            {
                if (attempt >= 3)
                {
                    return RedirectToAction("Results", "CME", new { id = caseID });
                }
                else
                {
                    attempt = (attempt + 1);
                }
            }
            else
            {
                attempt = 1;
            }
            bool IsEarned = myTestModel.IsEarned(userID, caseID);
            if (IsEarned == true)
            {
                return RedirectToAction("Results", "CME", new { id = caseID });
            }
            using (var db = new ModelDbContext())
            {
                foreach (var answerID in myTestModel.SelectedPostTestAnswer)
                {
                    int questionID = myTestModel.getQuestionID(answerID);

                    Data_Collection_Table collectAnswer = new Data_Collection_Table
                    {
                        User_Id = userID,
                        Answer_Id = answerID,
                        Pre_Test = 0,
                        Attempt = attempt,
                        Question_Id = questionID,
                        Case_Id = caseID
                    };
                    db.Add(collectAnswer);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Results", "CME", new { id = caseID });
        }
        //End Post Test

        //Begin Results
        [HttpGet]
        public ActionResult Results(string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "Result", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            int userID = int.Parse(Request.Cookies["uID"]);
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            TestModel myTestModel = new TestModel();
            myTestModel.UserId = userID.ToString();
            float rounded = myTestModel.getGrade(userID, caseID);
            using (var db = new ModelDbContext())
            {
                if (myTestModel.IsEarned(userID, caseID) == true)
                {
                    return RedirectToAction("Evaluation", "CME", new { id = caseID.ToString() });
                }
                else
                {
                    int? myAttempt = (from a in db.AttemptTable
                                      where a.Case_Id == caseID
                                      && a.User_Id == userID
                                      && a.Pre_Test == 0
                                      select a.Attempt_Id).Count();
                    Attempt_Table newAttempt = new Attempt_Table()
                    {
                        Attempt = myAttempt + 1,
                        User_Id = userID,
                        Case_Id = caseID,
                        Date_Time = DateTime.Now,
                        Pre_Test = 0
                    };
                    db.Add(newAttempt);
                    db.SaveChanges();
                }
                if (rounded >= 75)
                {
                    Earned_CE_Table earnedRecord = new Earned_CE_Table()
                    {
                        Case_Id = caseID,
                        User_Id = userID,
                        Date = DateTime.Now.ToShortDateString(),
                        Pass = 1
                    };
                    db.Add(earnedRecord);
                    db.SaveChanges();
                }
            }
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult Results(TestModel myModel, string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "Result", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            return RedirectToAction("Evaluation", "CME", new { id = caseID.ToString() });
        }
        //End Results

        //Begin Evaluation
        [HttpGet]
        public ActionResult Evaluation(string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "Evaluation", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            TestModel myTestModel = new TestModel();
            int userID = int.Parse(Request.Cookies["uID"].ToString());
            int caseID = 422;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            if (myTestModel.IsEvalAlreadyTaken(userID, caseID) != false)
            {
                return RedirectToAction("ClaimCredit", "CME", new { id = caseID });
            }
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult Evaluation(TestModel myModel, string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "Evaluation", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            TestModel myTestModel = myModel;
            int userID = int.Parse(Request.Cookies["uID"].ToString());
            int caseID = 422;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            if (myTestModel.IsEvalAlreadyTaken(userID, caseID) != false)
            {
                return RedirectToAction("ClaimCredit", "CME", new { id = caseID });
            }
            bool IsEarned = myTestModel.IsEarned(userID, caseID);
            if (IsEarned != true)
            {
                return RedirectToAction("PostTest", "CME", new { id = caseID });
            }
            //6)Confident
            //7)strongly agree
            //8)If Yes
            //10/Excellent
            //14/Text Only
            //22)Always Often
            int countEvalQuestions = myTestModel.getEvalQuestions(caseID).Count();
            int ifYesTextBoxAdder = 0;
            int textBoxOnlyAdder = 0;
            int selectedEvaluationAdder = 0;
            for (int i = 0; i < countEvalQuestions; i++)
            {
                List<int> questionIDs = myTestModel.getEvalQuestions(caseID).Select(x => x.Question_Id).ToList();
                int questionID = questionIDs[i];
                int questionType = myTestModel.getQuestionType(questionID);
                if (questionType == 6 || questionType == 7 || questionType == 10 || questionType == 22)
                {
                    Eval_Collector collectAnswer = new Eval_Collector
                    {
                        QuestionNum = (i + 1).ToString(),
                        EvalResponseNum = myTestModel.SelectedEvaluationAnswers[selectedEvaluationAdder],
                        EvalResponeText = null,
                        UserId = userID,
                        QuestionType = questionType,
                        EvalType = 1,
                        QuestionNumFK = questionID,
                        EvalId = caseID,
                        UpdateTime = DateTime.Now
                    };
                    using(var db = new ModelDbContext())
                    {
                        db.Add(collectAnswer);
                        db.SaveChanges();
                    }
                    
                    selectedEvaluationAdder++;
                }
                else if (questionType == 8)//If Yes
                {
                    Eval_Collector collectAnswer = new Eval_Collector
                    {
                        QuestionNum = (i + 1).ToString(),
                        EvalResponseNum = myTestModel.SelectedIfYesAnswers[ifYesTextBoxAdder],
                        EvalResponeText = myTestModel.ifYesText[ifYesTextBoxAdder],
                        UserId = userID,
                        QuestionType = questionType,
                        EvalType = 1,
                        QuestionNumFK = questionID,
                        EvalId = caseID,
                        UpdateTime = DateTime.Now
                    };
                    using (var db = new ModelDbContext())
                    {
                        db.Add(collectAnswer);
                        db.SaveChanges();
                    }
                    ifYesTextBoxAdder++;
                }
                else if (questionType == 14)//Text Only
                {
                    Eval_Collector collectAnswer = new Eval_Collector
                    {
                        QuestionNum = (i + 1).ToString(),
                        EvalResponseNum = null,
                        EvalResponeText = myTestModel.textOnly[textBoxOnlyAdder],
                        UserId = userID,
                        QuestionType = questionType,
                        EvalType = 1,
                        QuestionNumFK = questionID,
                        EvalId = caseID,
                        UpdateTime = DateTime.Now
                    };
                    using (var db = new ModelDbContext())
                    {
                        db.Add(collectAnswer);
                        db.SaveChanges();
                    }
                    textBoxOnlyAdder++;
                }

            }
            foreach (var answerID in myTestModel.SelectedEvaluationAnswers)
            {
                int questionID = myTestModel.getQuestionID(answerID);


            }
            //db.SubmitChanges();
            return RedirectToAction("ClaimCredit", "CME", new { id = id });
            //return View(myModel);
        }
        //End Evaluation

        //
        //Begin Claim Credit
        [HttpGet]
        public ActionResult ClaimCredit(string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "ClaimCredit", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            TestModel myTestModel = new TestModel();
            int caseID = int.Parse(id);
            int userId = int.Parse(Request.Cookies["uID"]);
            bool checkIfClaimed = myTestModel.IsCreditClaimed(caseID, userId);
            if (checkIfClaimed == true)
            {
                //return RedirectToAction("ActivityComplete", "CME", new { id = caseID });
            }
            myTestModel.claimedCredit = null;
            myTestModel.ReturnUrl = "~/CME/ClaimCredit";
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult ClaimCredit(TestModel myModel, string id)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "ClaimCredit", option);
            var check = User.Identity.IsAuthenticated;
            if (!check)
            {
                return RedirectToAction("Account", "Identity", new { id = "Login" });
            }
            int caseID = 0;
            int userId = int.Parse(Request.Cookies["uID"]);
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            using (var db = new ModelDbContext())
            {
                var updateEarned = from uE in db.EarnedCE
                                   where uE.Case_Id == caseID & uE.User_Id == userId
                                   select uE;
                foreach (Earned_CE_Table ec in updateEarned)
                {
                    ec.Claimed = myModel.claimedCredit;
                    ec.Type = myModel.claimedCreditType;
                    db.EarnedCE.Update(ec);
                }
                db.SaveChanges();

            }

            //myModel.sendMail(caseID, userID);
            return RedirectToAction("ActivityComplete", "CME", new { id = caseID });

        }
        //End Claim Credit
        //
        //Begin Activity Completed
        [HttpGet]
        public ActionResult ActivityComplete()
        {
            TestModel myTestModel = new TestModel();
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult ActivityComplete(TestModel model, string id)
        {
            string email = connections.Value.Email.email;
            string password = connections.Value.Email.password;
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1200);
            option.IsEssential = true;
            Response.Cookies.Append("CaseId", id, option);
            Response.Cookies.Append("lastVisited", "ActivityComplete", option);
            TestModel myTestModel = model;
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            int userID = 0;
            var checkUIDCookie = Request.Cookies["uID"];
            if (checkUIDCookie != null)
            {
                userID = int.Parse(Request.Cookies["uID"].ToString());
            }
            MailModel mail = new MailModel(caseID.ToString(),userID.ToString(), connections);
            mail.Envelope("my body of email", "to@email.com", "email subject", "Recipients name");
            //using (var db = new ModelDbContext())
            //{
                //var getClaimed = from c in db.EarnedCE where c.Case_Id == caseID && c.User_Id == userID select c.Type;
                //int claimed = 0;
                //if (getClaimed.FirstOrDefault() != null)
                //{
                //    claimed = int.Parse(getClaimed.FirstOrDefault().ToString());
                //}
                //if (claimed == 1)
                //{
                //    return RedirectToAction("Certificate", "CME", new { id = caseID });
                //}
                //if (claimed == 2)
                //{
                //    return RedirectToAction("NursingCertificate", "CME", new { id = caseID });
                //}
                //if (claimed == 3 || claimed == 4)
                //{
                //    return RedirectToAction("CDRCertificate", "CME", new { id = caseID });
                //}
                //if (claimed == 5)
                //{
                //    return RedirectToAction("ACPECertificate", "CME", new { id = caseID });
                //}
                //else
                //{
                    return RedirectToAction("Certificate", "CME", new { id = caseID });
                //}
            //}
        }
        //End Activity Completed
        //Begin certificate
        [HttpGet]
        public ActionResult Certificate()
        {
            TestModel myTestModel = new TestModel();
            int? userId = 0;
            int? uuId = 0;
            userId = int.Parse(Request.Cookies["uID"].ToString());
            var caseId = Request.Cookies["CaseId"];
            if(caseId != null && userId != null)
            {
                // redirect to manage/viewCertificate jhasim1
                using (var db = new ModelDbContext())
                {
                    uuId = db.Users.Where(x => x.User_Id == userId).Select(x => x.UId).FirstOrDefault();
                    Response.Redirect("http://www.jhasim1.com/Manage/ViewCertificate.aspx?case_id=" + caseId.ToString() + "&z=" + uuId.ToString());

                }
            }
            return View();
        }
            public IActionResult Index()
        {
            return View();
        }
    }
}