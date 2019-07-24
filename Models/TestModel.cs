using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static WebApplication5.Models.ModelDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        public string ReturnUrl = null;
        public string QuestionNumber = "0";
        public string CaseId = "0";
        public string UserId = "0";
        public int CrossLogin(string email, string first, string last, string degree, string specialty, string password)
        {
            int userId = 0;
            using (var db = new ModelDbContext())
            {
                var user = db.Users.Where(x => x.Email == email);
                if (user.Any())
                {

                }
                else
                {
                    // Create user account
                    User_Table newUser = new User_Table()
                    {
                        Email = email,
                        First_Name = first,
                        Last_Name = last,
                        Password = password,
                        Specialty = specialty,
                        Degree = degree,
                        User_Role_Id = 1

                    };
                    db.Add(newUser);
                    db.SaveChanges();
                    userId = newUser.User_Id;
                }

            }
            return userId;
        }
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
        public bool IsEvalAlreadyTaken(int userID, int caseID)
        {
            bool isEarned = false;
            int countEarned = 0;
            using (var db = new ModelDbContext())
            {
                countEarned = (from e in db.EvalCollector
                               where e.EvalId == caseID
                               && e.UserId == userID
                               select e.EntryId).Count();
            }
            if (countEarned > 0)
            {
                isEarned = true;
            }
            return isEarned;
        }
        public List<int> SelectedEvaluationAnswers { get; set; }
        public List<Question_Table> getEvalQuestions(int caseID)
        {
            List<Question_Table> evalQuestions = new List<Question_Table>();
            using (var db = new ModelDbContext())
            {
                evalQuestions = (from ev in db.QuestionTable
                                 where ev.Question_Type_Id > 4
                                 && ev.Case_Id == caseID
                                 select ev).ToList();
            }
            return evalQuestions;
        }
        public int getEvalQuestionType(int questionID)
        {
            int evalQuestions = 0;
            using (var db = new ModelDbContext())
            {
                evalQuestions = (from ev in db.QuestionTable
                                 where ev.Question_Type_Id > 4
                                 && ev.Question_Id == questionID
                                 select ev.Question_Type_Id).FirstOrDefault();
            }
            return evalQuestions;
        }

        public int getQuestionType(int questionID)
        {
            int questionType = 0;
            using (var db = new ModelDbContext())
            {
                questionType = (from q in db.QuestionTable
                                where q.Question_Id == questionID
                                select q.Question_Type_Id).FirstOrDefault();
            }
            return questionType;
        }
        public List<int> SelectedIfYesAnswers { get; set; }
        public List<string> ifYesText { get; set; }
        public List<string> textOnly { get; set; }

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
        [Required]
        [Range(0, 5)]
        [Display(Name = "Claim Credit")]
        public float? claimedCredit { get; set; }
        [Required]
        [Display(Name = "Claim Credit Type")]
        public int? claimedCreditType { get; set; }
        public double? getMaxCredit(int caseID)
        {
            double? maxCredit = 0;
            using (var db = new ModelDbContext())
            {
                maxCredit = ((from c in db.Cases
                              where c.Case_Id == caseID
                              select c.CME_Credits).FirstOrDefault());
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
        public class userModel
        {
            public bool checkIfUniqueIDExists(int uID)
            {
                bool ifExists = false;
                using (var db = new ModelDbContext())
                {
                    ifExists = db.Users
                        .Where(x => x.User_Id == uID)
                        .Select(x => x.UId)
                        .Any();
                }

                return ifExists;
            }
            public bool IsEmail(string email)
            {
                var db = new ModelDbContext();
                bool checkForExistingEmail = false;
                int checkEmail = (from e in db.Users where e.Email == email select e.User_Id).FirstOrDefault();
                if (checkEmail != 0)
                {
                    checkForExistingEmail = true;
                }
                return (checkForExistingEmail);
            }
            public int participantID { get; set; }
            [Required]
            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email Address ")]
            public string email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password ")]
            public string password { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name ")]
            public string firstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name ")]
            public string lastName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address ")]
            public string address { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Address 2 ")]
            public string address2 { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "City ")]
            public string city { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "State ")]
            public string state { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Zip ")]
            public string zipCode { get; set; }
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone ")]
            public string phone { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Designation ")]
            public string designation { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Specialty ")]
            public string specialty { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "NABP e-Profile ")]
            public string nabpNumber { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Birth Day  ")]
            public string birthDay { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Birth Month ")]
            public string birthMonth { get; set; }
            public List<SelectListItem> stateDDLList
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem { Value = "AL", Text = "Alabama" },
                    new SelectListItem { Value = "AK", Text = "Alaska" },
                    new SelectListItem { Value = "AZ", Text = "Arizona" },
                    new SelectListItem { Value = "AR", Text = "Arkansas" },
                    new SelectListItem { Value = "CA", Text = "California" },
                    new SelectListItem { Value = "CO", Text = "Colorado" },
                    new SelectListItem { Value = "CT", Text = "Connecticut" },
                    new SelectListItem { Value = "DE", Text = "Delaware" },
                    new SelectListItem { Value = "FL", Text = "Florida" },
                    new SelectListItem { Value = "GA", Text = "Georgia" },
                    new SelectListItem { Value = "HI", Text = "Hawaii" },
                    new SelectListItem { Value = "ID", Text = "Idaho" },
                    new SelectListItem { Value = "IL", Text = "Illinois" },
                    new SelectListItem { Value = "IN", Text = "Indiana" },
                    new SelectListItem { Value = "IA", Text = "Iowa" },
                    new SelectListItem { Value = "KS", Text = "Kansas" },
                    new SelectListItem { Value = "KY", Text = "Kentucky" },
                    new SelectListItem { Value = "LA", Text = "Louisiana" },
                    new SelectListItem { Value = "ME", Text = "Maine" },
                    new SelectListItem { Value = "MD", Text = "Maryland" },
                    new SelectListItem { Value = "MA", Text = "Massachusetts" },
                    new SelectListItem { Value = "MI", Text = "Michigan" },
                    new SelectListItem { Value = "MN", Text = "Minnesota" },
                    new SelectListItem { Value = "MS", Text = "Mississippi" },
                    new SelectListItem { Value = "MO", Text = "Missouri" },
                    new SelectListItem { Value = "MT", Text = "Montana" },
                    new SelectListItem { Value = "NC", Text = "North Carolina" },
                    new SelectListItem { Value = "ND", Text = "North Dakota" },
                    new SelectListItem { Value = "NE", Text = "Nebraska" },
                    new SelectListItem { Value = "NV", Text = "Nevada" },
                    new SelectListItem { Value = "NH", Text = "New Hampshire" },
                    new SelectListItem { Value = "NJ", Text = "New Jersey" },
                    new SelectListItem { Value = "NM", Text = "New Mexico" },
                    new SelectListItem { Value = "NY", Text = "New York" },
                    new SelectListItem { Value = "OH", Text = "Ohio" },
                    new SelectListItem { Value = "OK", Text = "Oklahoma" },
                    new SelectListItem { Value = "OR", Text = "Oregon" },
                    new SelectListItem { Value = "PA", Text = "Pennsylvania" },
                    new SelectListItem { Value = "RI", Text = "Rhode Island" },
                    new SelectListItem { Value = "SC", Text = "South Carolina" },
                    new SelectListItem { Value = "SD", Text = "South Dakota" },
                    new SelectListItem { Value = "TN", Text = "Tennessee" },
                    new SelectListItem { Value = "TX", Text = "Texas" },
                    new SelectListItem { Value = "UT", Text = "Utah" },
                    new SelectListItem { Value = "VT", Text = "Vermont" },
                    new SelectListItem { Value = "VA", Text = "Virginia" },
                    new SelectListItem { Value = "WA", Text = "Washington" },
                    new SelectListItem { Value = "WV", Text = "West Virginia" },
                    new SelectListItem { Value = "WI", Text = "Wisconsin" },
                    new SelectListItem { Value = "WY", Text = "Wyoming" }
                };
                }
            }
            public List<SelectListItem> specialtyDDLList
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem { Value = "Academic", Text = "Academic" },
                    new SelectListItem { Value = "Adolescent Medicine", Text = "Adolescent Medicine" },
                    new SelectListItem { Value = "Allergy", Text = "Allergy" },
                    new SelectListItem { Value = "Allergy &amp, Immunology", Text = "Allergy &amp, Immunology" },
                    new SelectListItem { Value = "Anesthesiology", Text = "Anesthesiology" },
                    new SelectListItem { Value = "Cardiology", Text = "Cardiology" },
                    new SelectListItem { Value = "Cardiovascular Surgery", Text = "Cardiovascular Surgery" },
                    new SelectListItem { Value = "Cataract / IOL", Text = "Cataract / IOL" },
                    new SelectListItem { Value = "Clinical", Text = "Clinical" },
                    new SelectListItem { Value = "Community Pharmacist", Text = "Community Pharmacist" },
                    new SelectListItem { Value = "Comprehensive Ophthalomology", Text = "Comprehensive Ophthalomology" },
                    new SelectListItem { Value = "Contact Lenses", Text = "Contact Lenses" },
                    new SelectListItem { Value = "Critical Care Medicine", Text = "Critical Care Medicine" },
                    new SelectListItem { Value = "Dermatology", Text = "Dermatology" },
                    new SelectListItem { Value = "Diabetes", Text = "Diabetes" },
                    new SelectListItem { Value = "Emergency Medicine", Text = "Emergency Medicine" },
                    new SelectListItem { Value = "Endocrinology", Text = "Endocrinology" },
                    new SelectListItem { Value = "Family Practice", Text = "Family Practice" },
                    new SelectListItem { Value = "Gastroenterology", Text = "Gastroenterology" },
                    new SelectListItem { Value = "General Dentistry", Text = "General Dentistry" },
                    new SelectListItem { Value = "General Practice", Text = "General Practice" },
                    new SelectListItem { Value = "Geriatrics", Text = "Geriatrics" },
                    new SelectListItem { Value = "Gynecology", Text = "Gynecology" },
                    new SelectListItem { Value = "Hematology", Text = "Hematology" },
                    new SelectListItem { Value = "Hematology &amp, Oncology", Text = "Hematology &amp, Oncology" },
                    new SelectListItem { Value = "Hospital Pharmacist", Text = "Hospital Pharmacist" },
                    new SelectListItem { Value = "Immunology", Text = "Immunology" },
                    new SelectListItem { Value = "Institutional Pharmacist", Text = "Institutional Pharmacist" },
                    new SelectListItem { Value = "Infectious Diseases", Text = "Infectious Diseases" },
                    new SelectListItem { Value = "Internal Medicine", Text = "Internal Medicine" },
                    new SelectListItem { Value = "Internal Medicine/Geriatrics", Text = "Internal Medicine/Geriatrics" },
                    new SelectListItem { Value = "Internal Medicine/Pediatrics ", Text = "Internal Medicine/Pediatrics " },
                    new SelectListItem { Value = "Long Term Care", Text = "Long Term Care" },
                    new SelectListItem { Value = "Managed Care", Text = "Managed Care" },
                    new SelectListItem { Value = "Maternal/Fetal Medicine", Text = "Maternal/Fetal Medicine" },
                    new SelectListItem { Value = "Medical Genetics", Text = "Medical Genetics" },
                    new SelectListItem { Value = "Neonatalogy", Text = "Neonatalogy" },
                    new SelectListItem { Value = "Nephrology", Text = "Nephrology" },
                    new SelectListItem { Value = "Neurological Surgery", Text = "Neurological Surgery" },
                    new SelectListItem { Value = "Neurology", Text = "Neurology" },
                    new SelectListItem { Value = "Ob/Gyn", Text = "Ob/Gyn" },
                    new SelectListItem { Value = "Obstetrics", Text = "Obstetrics" },
                    new SelectListItem { Value = "Occupational Medicine", Text = "Occupational Medicine" },
                    new SelectListItem { Value = "Occupational Therapy", Text = "Occupational Therapy" },
                    new SelectListItem { Value = "Oncology", Text = "Oncology" },
                    new SelectListItem { Value = "Ophthalmology", Text = "Ophthalmology" },
                    new SelectListItem { Value = "Optics / Refraction", Text = "Optics / Refraction" },
                    new SelectListItem { Value = "Optometry", Text = "Optometry" },
                    new SelectListItem { Value = "Orthopedic Surgery", Text = "Orthopedic Surgery" },
                    new SelectListItem { Value = "Other", Text = "Other" },
                    new SelectListItem { Value = "Otolaryngologist", Text = "Otolaryngologist" },
                    new SelectListItem { Value = "Pain Management", Text = "Pain Management" },
                    new SelectListItem { Value = "Pathology", Text = "Pathology" },
                    new SelectListItem { Value = "Pediatrics", Text = "Pediatrics" },
                    new SelectListItem { Value = "Pharmacology, Clinical", Text = "Pharmacology, Clinical" },
                    new SelectListItem { Value = "Physical Medicine &amp, Rehabilitation", Text = "Physical Medicine &amp, Rehabilitation" },
                    new SelectListItem { Value = "Plastic & Reconstructive Surgery", Text = "Plastic & Reconstructive Surgery" },
                    new SelectListItem { Value = "Podiatry", Text = "Podiatry" },
                    new SelectListItem { Value = "Preventive Medicine", Text = "Preventive Medicine" },
                    new SelectListItem { Value = "Psychiatry", Text = "Psychiatry" },
                    new SelectListItem { Value = "Public Health", Text = "Public Health" },
                    new SelectListItem { Value = "Pulmonary Disease", Text = "Pulmonary Disease" },
                    new SelectListItem { Value = "Radiology", Text = "Radiology" },
                    new SelectListItem { Value = "Respiratory Therapy", Text = "Respiratory Therapy" },
                    new SelectListItem { Value = "Retina / Vitreous Surgery", Text = "Retina / Vitreous Surgery" },
                    new SelectListItem { Value = "Rheumatology", Text = "Rheumatology" },
                    new SelectListItem { Value = "Sports Medicine", Text = "Sports Medicine" },
                    new SelectListItem { Value = "Surgery, General", Text = "Surgery, General" },
                    new SelectListItem { Value = "Surgery, Vascular", Text = "Surgery, Vascular" },
                    new SelectListItem { Value = "Urology", Text = "Urology" }
                };
                }
            }
            public List<SelectListItem> designationDDLList
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem { Value = "MD", Text = "MD" },
                    new SelectListItem { Value = "CPHT", Text = "CPHT" },
                    new SelectListItem { Value = "CRNA", Text = "CRNA" },
                    new SelectListItem { Value = "DDS", Text = "DDS" },
                    new SelectListItem { Value = "DMD", Text = "DMD" },
                    new SelectListItem { Value = "DO", Text = "DO" },
                    new SelectListItem { Value = "DPM", Text = "DPM" },
                    new SelectListItem { Value = "EMT", Text = "EMT" },
                    new SelectListItem { Value = "LPN", Text = "LPN" },
                    new SelectListItem { Value = "MT", Text = "MT" },
                    new SelectListItem { Value = "Medical Student", Text = "Medical Student" },
                    new SelectListItem { Value = "NP", Text = "NP" },
                    new SelectListItem { Value = "OD", Text = "OD" },
                    new SelectListItem { Value = "OT", Text = "OT" },
                    new SelectListItem { Value = "Other", Text = "Other" },
                    new SelectListItem { Value = "PA", Text = "PA" },
                    new SelectListItem { Value = "PT", Text = "PT" },
                    new SelectListItem { Value = "PhD", Text = "PhD" },
                    new SelectListItem { Value = "PharmD", Text = "PharmD" },
                    new SelectListItem { Value = "RD", Text = "RD" },
                    new SelectListItem { Value = "RN", Text = "RN" },
                    new SelectListItem { Value = "RN, CDE", Text = "RN, CDE" },
                    new SelectListItem { Value = "RPh", Text = "RPh" },
                    new SelectListItem { Value = "RT", Text = "RT" }
                };
                }
            }
            public List<SelectListItem> monthDDLList
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem { Value = "1", Text = "Jan" },
                    new SelectListItem { Value = "2", Text = "Feb" },
                    new SelectListItem { Value = "3", Text = "Mar" },
                    new SelectListItem { Value = "4", Text = "Apr" },
                    new SelectListItem { Value = "5", Text = "May" },
                    new SelectListItem { Value = "6", Text = "June" },
                    new SelectListItem { Value = "7", Text = "July" },
                    new SelectListItem { Value = "8", Text = "Aug" },
                    new SelectListItem { Value = "9", Text = "Sept" },
                    new SelectListItem { Value = "10", Text = "Oct" },
                    new SelectListItem { Value = "11", Text = "Nov" },
                    new SelectListItem { Value = "12", Text = "Dec" }
                };
                }
            }
            public List<SelectListItem> dayDDLList
            {
                get
                {
                    return new List<SelectListItem>()
                {
                    new SelectListItem { Value = "1", Text = "1" },
                    new SelectListItem { Value = "2", Text = "2" },
                    new SelectListItem { Value = "3", Text = "3" },
                    new SelectListItem { Value = "4", Text = "4" },
                    new SelectListItem { Value = "5", Text = "5" },
                    new SelectListItem { Value = "6", Text = "6" },
                    new SelectListItem { Value = "7", Text = "7" },
                    new SelectListItem { Value = "8", Text = "8" },
                    new SelectListItem { Value = "9", Text = "9" },
                    new SelectListItem { Value = "10", Text = "10" },
                    new SelectListItem { Value = "11", Text = "11" },
                    new SelectListItem { Value = "12", Text = "12" },
                    new SelectListItem { Value = "13", Text = "13" },
                    new SelectListItem { Value = "14", Text = "14" },
                    new SelectListItem { Value = "15", Text = "15" },
                    new SelectListItem { Value = "16", Text = "16" },
                    new SelectListItem { Value = "17", Text = "17" },
                    new SelectListItem { Value = "18", Text = "18" },
                    new SelectListItem { Value = "19", Text = "19" },
                    new SelectListItem { Value = "20", Text = "20" },
                    new SelectListItem { Value = "21", Text = "21" },
                    new SelectListItem { Value = "22", Text = "22" },
                    new SelectListItem { Value = "23", Text = "23" },
                    new SelectListItem { Value = "24", Text = "24" },
                    new SelectListItem { Value = "25", Text = "25" },
                    new SelectListItem { Value = "26", Text = "26" },
                    new SelectListItem { Value = "27", Text = "27" },
                    new SelectListItem { Value = "28", Text = "28" },
                    new SelectListItem { Value = "29", Text = "29" },
                    new SelectListItem { Value = "30", Text = "30" },
                    new SelectListItem { Value = "31", Text = "31" }
                };
                }
            }
            public List<int?> accountPrePostHistory(int? userID, int prePostNumber)
            {
                List<int?> history = new List<int?>();
                using (var db = new ModelDbContext())
                {
                    history = db.DataCollectionTable
                        .Where(x => x.User_Id == userID
                        && x.Pre_Test == prePostNumber)
                        .Select(x => x.Case_Id)
                        .Distinct()
                        .ToList();
                }

                return history;
            }
            public List<int?> accountEvaluationHistory(int? userID, int caseID)
            {
                List<int?> history = new List<int?>();
                using (var db = new ModelDbContext())
                {
                    history = db.EvalCollector
                        .Where(x => x.EvalId == caseID
                        && x.UserId == userID)
                        .Select(x => x.EvalId)
                        .Distinct()
                        .ToList();
                }

                return history;
            }
            public int countPostAttempts(int caseID, int userID)
            {
                int attemptCount = 0;
                using (var db = new ModelDbContext())
                {
                    attemptCount = db.DataCollectionTable
                        .Where(x => x.Case_Id == caseID
                        && x.User_Id == userID
                        && x.Pre_Test == 0)
                        .Select(x => x.Attempt)
                        .Distinct()
                        .Count();
                }

                return attemptCount;
            }
            public List<Earned_CE_Table> earnedList(int caseID, int userID)
            {
                List<Earned_CE_Table> earned = new List<Earned_CE_Table>();
                using(var db = new ModelDbContext())
                {
                    earned = db.EarnedCE
                        .Where(x => x.User_Id == userID
                        && x.Case_Id == caseID)
                        .ToList();
                }

                return earned;
            }
            public List<Case_Table> activityData(int caseID)
            {
                List<Case_Table> activity = new List<Case_Table>();
                using(var db = new ModelDbContext())
                {
                    activity = db.Cases
                        .Where(x => x.Case_Id == caseID)
                        .ToList();
                }

                return activity;
            }

            public string SelectedSourceAnswer { get; set; }
            //[Serializable]
            public class sourceRecord
            {
                public string ipAddress { get; set; }
                public string sourceSelection { get; set; }
                public string date { get; set; }

            }
        }
    }
}
