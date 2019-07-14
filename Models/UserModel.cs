using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication5.Models.ModelDbContext;

namespace WebApplication5.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        
        public bool checkIfUniqueIDExists(int uID)
        {
            bool ifExists = false;

            using(var db = new ModelDbContext())
            {
                ifExists = db.Users
                    .Where(X => X.UId == uID)
                    .Select(x => x.UId)
                    .Any();
            }

            return ifExists;
        }
        public bool IsEmail(string email)
        {
            bool checkForExistingEmail = false;
            using(var db = new ModelDbContext())
            {
                checkForExistingEmail = db.Users
                    .Where(x => x.Email == email)
                    .Select(x => x.User_Id)
                    .Any();
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
                history = db.DataCollectionTable.Where(x => x.User_Id == userID
                && x.Pre_Test == prePostNumber
                ).Select(x => x.Case_Id).Distinct().ToList();
            }
            //history = history.Where(x => x.Value == 28).ToList();

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
            using(var db = new ModelDbContext())
            {
                attemptCount = db.DataCollectionTable
                    .Where(x => x.User_Id == userID
                    && x.Case_Id == caseID
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
                    .Where(x => x.Case_Id == caseID
                    && x.User_Id == userID)
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
