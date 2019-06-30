using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static WebApplication5.Models.ModelDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication5.Models
{
    public class TestModel
    {
        public TestModel()
        {

        }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestModel(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public string QuestionNumber = "0";
        public string CaseId = "0";
        public string UserId = "0";
        public List<Question_Table> getActivityQuestions(string id)
        {
            int caseId = int.Parse(id);
            //int questionIndex = qNum;

            if (id != null)
            {
                caseId = int.Parse(id);
            }
            List<Question_Table> getQuestionList = new List<Question_Table>();
            using (var db = new ModelDbContext())
            {
                getQuestionList = db.QuestionTable.Where(x => x.Case_Id == caseId && x.Question_Type_Id == 2).ToList();
            }
            return getQuestionList;
        }

        public List<Answer_Table> getAnswers(int questionID)
        {
            List<Answer_Table> answers = new List<Answer_Table>();
            using (var db = new ModelDbContext())
            {
                answers = (from a in db.AnswerTable
                           where a.Question_Id == questionID
                           select a).ToList();
            }
            return answers;
        }

        //
        public int? getAttemptCount(int uID, string caseId)
        {
            int caseID = int.Parse(caseId);

            List<int?> getAttempt = new List<int?>();
            using (var db = new ModelDbContext())
            {
                getAttempt = (from q in db.DataCollectionTable
                              where q.Case_Id == caseID
                              && q.User_Id == uID
                              && q.Attempt != null
                              orderby q.Attempt descending
                              select q.Attempt)
                                  .Distinct()
                                  .ToList();
            }
            int countAttempts = getAttempt.Count();
            return countAttempts;
        }
        //

        public List<int> SelectedPreTestAnswer { get; set; }
        public List<Question_Table> getPreTestQuestions(string id)
        {
            int caseID = 422;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            List<Question_Table> getQuestionList = new List<Question_Table>();
            using (var db = new ModelDbContext())
            {
                getQuestionList = db.QuestionTable
                    .Where(x => x.Case_Id == caseID
                        && x.Question_Type_Id == 1
                        || x.Case_Id == caseID
                        && x.Question_Type_Id == 4
                        ).ToList();
            }
            return getQuestionList;
        }
        public int getQuestionID(int answerID)
        {
            int questionId = 0;
            using (var db = new ModelDbContext())
            {
                questionId = (from q in db.AnswerTable
                              where q.Answer_Id == answerID
                              select q.Question_Id).FirstOrDefault();
            }
            return questionId;

        }
        public string SelectedAnswer { get; set; }

        //
        //
        public List<Question_Table> getEvalQuestions(string id)
        {
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            List<Question_Table> getQuestionList = new List<Question_Table>();
            using (var db = new ModelDbContext())
            {
                getQuestionList =
                (from qt in db.QuestionTable
                 where qt.Case_Id == caseID
                 && qt.Question_Type_Id > 4
                 select qt)
                 .ToList();
            }

            return getQuestionList;
        }
        public bool IsCorrect(int answerID)
        {
            bool isCorrect = new bool();
            isCorrect = false;
            string correct = "";
            using (var db = new ModelDbContext())
            {
                correct = (from c in
                               db.AnswerTable
                           where c.Answer_Id == answerID
                           select c.Answer_Correct)
                           .FirstOrDefault()
                           .ToString();
            }
            int correctInt = int.Parse(correct.ToString());
            if (correctInt != 0)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
        public string getAnswerExplanation(int answerID)
        {
            //var routeData = _httpContextAccessor.HttpContext.Request.Path.ToUriComponent();//.RouteData.Values["id"]; // HttpContext.Current.Request.RequestContext.RouteData;
            //var routeData1 = _httpContextAccessor.HttpContext.Request.Path.Value;
            //var routeData2 = _httpContextAccessor.HttpContext.Request.QueryString.Value;// "q"];
            //var routeData3 = _httpContextAccessor.HttpContext.Request.QueryString;// "q"];
            int caseID = 783;

            //if ( routeData.Values["id"] != null)
            //{
            //    caseID = int.Parse(routeData.Values["id"].ToString());
            //}
            string getExplainList = "";
            using (var db = new ModelDbContext())
            {
                getExplainList = (from e in db.AnswerTable where e.Answer_Id == answerID select e.answer_explanation).FirstOrDefault().ToString();
            }

            return getExplainList;
        }

        //
        //
        public List<Answer_Table> Answers
        {
            get
            {
                var qVal = 0;
                List<Answer_Table> getAnswers = new List<Answer_Table>();
                int caseID = int.Parse(CaseId);
                int q = int.Parse(QuestionNumber);
                int questionID = getActivityQuestions(caseID.ToString()).Select(x => x.Question_Id).Skip(q).FirstOrDefault();
                using (var db = new ModelDbContext())
                {
                    getAnswers = (from a in db.AnswerTable
                                  where a.case_id == caseID
                                  && a.Question_Id == questionID
                                  select a).ToList();
                }
                return getAnswers;
            }
        }

        public bool IsEarned(int userID, int caseID)
        {
            bool isEarned = false;
            int countEarned = 0;
            using (var db = new ModelDbContext())
            {
                countEarned = (from e in db.EarnedCE
                               where e.Case_Id == caseID
                               && e.User_Id == userID
                               select e.Earned_CE_Id).Count();
            }
            if (countEarned > 0)
            {
                isEarned = true;
            }
            return isEarned;
        }
        //

        //
        public int? getAttemptCount(int uID, int myCaseId)
        {
            int caseID = myCaseId;
            List<int?> attempts = new List<int?>();
            using (var db = new ModelDbContext())
            {
                attempts = (from q in db.DataCollectionTable
                            where q.Case_Id == caseID
                            && q.User_Id == uID
                            && q.Attempt != null
                            orderby q.Attempt descending
                            select q.Attempt)
                                  .Distinct()
                                  .ToList();
            }

            int countAttempts = attempts.Count();
            return countAttempts;
        }
        //

        public List<Question_Table> getPostTestQuestions(string id)
        {
            int caseID = 0;
            if (id != null)
            {
                caseID = int.Parse(id);
            }
            List<Question_Table> getQuestionList = new List<Question_Table>();
            using (var db = new ModelDbContext())
            {
                getQuestionList =
                    (from qt in db.QuestionTable
                     where qt.Case_Id == caseID && qt.Question_Type_Id == 3
                     || qt.Case_Id == caseID && qt.Question_Type_Id == 4
                     select qt).ToList();
            }

            return getQuestionList;
        }//

        public List<int> SelectedPostTestAnswer { get; set; }

        //


        //
        public float getGrade(int userID, int caseID)
        {
            int? attempt = getAttemptCount(userID, caseID);
            List<Data_Collection_Table> getAnswers = new List<Data_Collection_Table>();
            float rounded = 0;
            using (var db = new ModelDbContext())
            {
                getAnswers = (from a in db.DataCollectionTable
                              where a.Case_Id == caseID
                              && a.User_Id == userID
                              && a.Attempt == attempt
                              select a).ToList();

                int numberOfAnswers = getAnswers.Count();
                int numberCorrect = 0;
                foreach (Data_Collection_Table answers in getAnswers)
                {
                    var answerCorrect = db.AnswerTable
                        .Where(x => x.case_id == caseID && x.Answer_Id == answers.Answer_Id)
                        .Select(x => x.Answer_Correct)
                        .SingleOrDefault();
                    if (answerCorrect == 0)
                    {
                        //incorrect
                    }
                    else
                    {
                        numberCorrect++; //correct
                    }
                }
                float grade = (float.Parse(numberCorrect.ToString()) / float.Parse(numberOfAnswers.ToString())) * 100;
                decimal round = Math.Round((Decimal)grade, 1, MidpointRounding.AwayFromZero);
                rounded = float.Parse(round.ToString());
            }
            return rounded;
        }
        //

        //
        public List<User_Table> getParticipantData(int userID)
        {
            List<User_Table> user = new List<User_Table>();
            using (var db = new ModelDbContext())
            {
                user = (from u in db.Users
                        where u.User_Id == userID
                        select u).ToList();
            }
            return user;
        }
        public List<User_Table> getParticipantDataByUID(int userID)
        {
            List<User_Table> user = new List<User_Table>();
            using (var db = new ModelDbContext())
            {
                user = (from u in db.Users
                        where u.User_Id == userID
                        select u).ToList();
            }
            return user;
        }
        public int getParticipantUserIDByUID(int uID)
        {
            int user = 0;
            using (var db = new ModelDbContext())
            {
                user = (from u in db.Users
                        where u.UId == uID
                        select u.User_Id).SingleOrDefault();
            }
            return user;
        }
        public List<Case_Table> getActivityData(int caseID)
        {
            List<Case_Table> activityData = new List<Case_Table>();
            using (var db = new ModelDbContext())
            {
                activityData = db.Cases.Where(x => x.Case_Id == caseID).ToList();
            }
            return activityData;
        }
        public List<Earned_CE_Table> getEarnedCeRecord(int caseID, int userID)
        {
            List<Earned_CE_Table> earnedRecord = new List<Earned_CE_Table>();
            using (var db = new ModelDbContext())
            {
                earnedRecord = (from c in db.EarnedCE
                                where c.Case_Id == caseID
                                && c.User_Id == userID
                                select c).ToList();
            }

            return earnedRecord;
        }
        public bool IsCreditClaimed(int caseID, int userID)
        {
            bool claimed = false;
            int getClaimedRecord = 0;
            using (var db = new ModelDbContext())
            {
                getClaimedRecord = (from c in db.EarnedCE
                                    where c.User_Id == userID
                                    && c.Case_Id == caseID
                                    && c.Claimed != null
                                    select c.Claimed).Count();
            }
            if (getClaimedRecord != 0)
            {
                claimed = true;
            }
            return claimed;

        }
        //
        //

        public int claimedCredit { get; set; }
        public int? claimedCreditType { get; set; }
        public float? getMaxCredit(int caseID)
        {
            int maxCredit = 0;
            using (var db = new ModelDbContext())
            {
                maxCredit = int.Parse((from c in db.Cases
                                     where c.Case_Id == caseID
                                     select c.CME_Credits).FirstOrDefault().ToString());
            }
                
            return maxCredit;
        }
        //
        //
        public List<SelectListItem> DDLList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Text = "Doctor",
                        Value = "1",
                        Selected = true
                    },
                    new SelectListItem
                    {
                        Selected = false,
                        Value = "2",
                        Text = "Nurse"
                    },
                    new SelectListItem
                    {
                        Text = "RD",
                        Value = "3",
                        Selected = false
                    },
                    new SelectListItem
                    {
                        Selected = false,
                        Value = "4",
                        Text = "DTR"
                    },
                    new SelectListItem
                    {
                        Selected = false,
                        Value = "5",
                        Text = "Pharmacist"
                    }
                };
            }
        }
        //
    }
}
