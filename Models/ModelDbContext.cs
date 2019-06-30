using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class ModelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("JhasioConnection"));
        }
        [Table("User_Table")]
        public class User_Table
        {
            [Key]
            public int User_Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public int? UId { get; set; }
        }
        public DbSet<User_Table> Users { get; set; }

        [Table("Case_Table")]
        public class Case_Table
        {
            [Key]
            public int Case_Id { get; set; }
            public string Case_Title { get; set; }
            public string CE_Data { get; set; }
            public double? CME_Credits { get; set; }
            public double? CNE_Credits { get; set; }
        }
        public DbSet<Case_Table> Cases { get; set; }

        [Table("Data_Collection_Table")]
        public class Data_Collection_Table
        {
            [Key]
            public int Result_Id { get; set; }
            public int User_Id { get; set; }
            public int Answer_Id { get; set; }
            public int ?Answer_Value { get; set; }
            public int? Pre_Test { get; set; }
            public int? Attempt { get; set; }
            public int? Question_Id { get; set; }
            public string AnswerTextValue { get; set; }
            public DateTime? FromMobileDate{ get; set; }
            public int? Case_Id { get; set; }
            public DateTime? UpdateTime { get; set; }
        }
        public DbSet<Data_Collection_Table> DataCollectionTable { get; set; }

        //
        [Table("Question_Table")]
        public class Question_Table
        {
            [Key]
            public int Question_Id { get; set; }
            public string question_text { get; set; }
            public int Question_Type_Id { get; set; }
            public string Opening_Text { get; set; }
            public int Case_Id { get; set; }
            public string QLabel { get; set; }
            public string SpecialtyType { get; set; }
            public string DesignationType { get; set; }
            public DateTime? UpdateTime { get; set; }
        }
        public DbSet<Question_Table> QuestionTable { get; set; }
        [Table("Answer_Table")]
        public class Answer_Table
        {
            [Key]
            public int Answer_Id { get; set; }
            public int Question_Id { get; set; }
            public string Answer_Text { get; set; }
            public int? Answer_Correct { get; set; }
            public string answer_explanation { get; set; }
            public int? case_id { get; set; }
            public int? NextQuestion { get; set; }
            public DateTime? UpdateTime { get; set; }
            //public EntitySet<Data_Collection_Table> _Data_Collection_Tables;
            //public EntityRef<Question_Table> _Question_Table;
        }
        public DbSet<Answer_Table> AnswerTable { get; set; }

        [Table("Attempt_Table")]
        public class Attempt_Table
        {
            [Key]
            public int Attempt_Id { get; set; }
            public int User_Id { get; set; }
            public int Case_Id { get; set; }
            public int Pre_Test { get; set; }
            public System.Nullable<DateTime> Date_Time { get; set; }
            public System.Nullable<int> Attempt { get; set; }
        }
        public DbSet<Attempt_Table> AttemptTable { get; set; }

        //
        [Table("Earned_CE")]
        public class Earned_CE_Table
        {
            [Key]
            public int Earned_CE_Id { get; set; }
            public int? Case_Id { get; set; }
            public int? User_Id { get; set; }
            public int? Pass { get; set; }
            public int? Type { get; set; }
            public string Date { get; set; }
            public float? Claimed { get; set; }
        }
        public DbSet<Earned_CE_Table> EarnedCE { get; set; }

        //
        public class asimQuestion
        {
            public int question_id { get; set; }
            public string question_text { get; set; }
        }
        public class asimAnswer
        {
            public int answer_id { get; set; }
            public string answer_text { get; set; }
            public int question_id { get; set; }
        }
        public class asimCEData
        {
            public int case_id { get; set; }
            public string ce_data { get; set; }
            public int learnin_area_id { get; set; }
            public float cme_credits { get; set; }
            public DateTime ce_release { get; set; }
            public DateTime ce_expire { get; set; }
        }
        public class MyViewModel
        {
            public bool IsFemale { get; set; }
        }
        public class mySelected
        {
            public int questionID { get; set; }
            public int answerID { get; set; }
            public string answerText { get; set; }
        }
        public class asimViewModel
        {
            public IEnumerable<asimQuestion> caseQuestions { get; set; }
            public IEnumerable<asimAnswer> questionAnswers { get; set; }
            public IEnumerable<asimCEData> myCEData { get; set; }
            public IEnumerable<mySelected> mySelected { get; set; }
            public bool IsFemale { get; set; }
        }
    }
}
