
namespace WebApplication5.Models
{
    public class AppSettings
    {
        public object connectionSettings { get; set; }
        public DBConnectionClass ConnectionStrings { get; set; }
        public string defaultConnection { get; set; }
        public FilesConnectionClass Files { get; set; }

        public EmailClass Email { get; set; }
        public class EmailClass
        {
            public string email { get; set; }
            public string password{ get; set; }
            public string smtp { get; set; }
            public int port { get; set; }
        }
        public class DBConnectionClass
        {
            public string defaultConnection { get; set; }
        }
        public class FilesConnectionClass
        {
            public string defaultFile { get; set; }
        }
        public MailConnectionClass MailConnection { get; set; }
        public class MailConnectionClass
        {
            public string password { get; set; }
            public string email { get; set; }
        }
    }
}
