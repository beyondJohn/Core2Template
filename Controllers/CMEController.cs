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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CMEController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        //Begin PreTest
        public ActionResult PreTest(string id)
        {
            int myId = int.Parse(id.ToString());
            //read cookie from IHttpContextAccessor  
            //
            var loggedIn = _httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
            //read cookie from Request object  
            string caseId = Request.Cookies["CaseId"];
            string userId = Request.Cookies["UserId"];

            //if (!userId.Any())
            //    return RedirectToAction("Login", "User");

            //if (!caseId.Any())
            //    return RedirectToAction("Index", "Home");

            //
            int checkTaken = 0;
            using (var db = new ModelDbContext())
            {
                var cId = int.Parse(caseId);
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
                //return RedirectToAction("Activity", "CME", new { id = caseId, q = 0 });
            }
            var questionsList = new TestModel(_httpContextAccessor).getActivityQuestions(caseId);
            var testModel = new TestModel(_httpContextAccessor);
            return View(testModel);

        }
        [HttpPost]
        public ActionResult PreTest(TestModel myModel, IFormCollection form, string id)
        {
            TestModel myTestModel = myModel;
            int userID = int.Parse(Request.Cookies["UserId"]);
            int caseID = int.Parse(Request.Cookies["CaseId"]);
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
        public ActionResult Activity()
        {
            TestModel myTestModel = new TestModel();
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult Activity(TestModel myModel)
        {
            return View(myModel);
        }
        //End Activity

        //Begin Post-Test
        [HttpGet]
        public ActionResult PostTest(string id)
        {
            if (Request.Cookies["uID"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            TestModel myTestModel = new TestModel();

            int userID = 0;// int.Parse(Request.Cookies["uID"].Value.ToString());

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
            if (Request.Cookies["uID"] == null)
            {
                return RedirectToAction("Login", "User");
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
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            return RedirectToAction("Evaluation", "CME", new { id = caseID.ToString() });
        }
        //End Results

        //
        //Begin Claim Credit
        [HttpGet]
        public ActionResult ClaimCredit(string id)
        {
            TestModel myTestModel = new TestModel();
            int caseID = int.Parse(id);
            int userId = int.Parse(Request.Cookies["UserId"]);
            bool checkIfClaimed = myTestModel.IsCreditClaimed(caseID, userId);
            if (checkIfClaimed == true)
            {
                return RedirectToAction("ActivityComplete", "CME", new { id = caseID });
            }
            return View(myTestModel);
        }
        [HttpPost]
        public ActionResult ClaimCredit(TestModel myModel, string id)
        {
            int caseID = 0;
            int userId = int.Parse(Request.Cookies["UserId"]);
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
                    db.Add(ec);
                }
                db.SaveChanges();

            }

            //myModel.sendMail(caseID, userID);
            return RedirectToAction("ActivityComplete", "CME", new { id = caseID });

        }
        //End Claim Credit
        //
        public IActionResult Index()
        {
            return View();
        }
    }
}