using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;

namespace WebApplication5.Models
{
    public class MailModel
    {
        private readonly AppSettings _connections;
        public readonly string _caseId;
        public readonly string _userId;

        public MailModel(string caseId, string userId,IOptions<AppSettings> appsettings)
        {
            _connections = appsettings.Value;
            _caseId = caseId;
            _userId = userId;
        }

        public void Envelope(string body, string to, string subject, string toName ){

            var envelope = new MyEnvelope();
            envelope.password = _connections.Email.password;
            envelope.body = "<b>Testing: </b> <span style=\"color:red;\">The mailkit system.</span>";
            envelope.fromAddress = _connections.Email.email;
            envelope.fromName = "Beyond Logical";
            envelope.port = _connections.Email.port;
            envelope.smtp = _connections.Email.smtp;
            envelope.subject = "Final - Test email from myself to myself - Final";
            envelope.toAddress = "jpjpiesco@gmail.com";
            envelope.toName = "JP Piesco";
            envelope.username = _connections.Email.email;
            //Send(envelope);
        }
        public void Send(MyEnvelope envelope)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(envelope.fromName, envelope.fromAddress));
            message.To.Add(new MailboxAddress(envelope.toName, envelope.toAddress));
            message.Subject = envelope.subject;

            message.Body = new TextPart("html")
            {
                Text = envelope.body
            };
            using (var client = new SmtpClient())
            {
                client.Connect(envelope.smtp, envelope.port);
                client.Authenticate(envelope.username, envelope.password);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public class MyEnvelope
        {
            public string toAddress { get; set; }
            public string toName { get; set; }
            public string fromAddress { get; set; }
            public string fromName { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string smtp { get; set; }
            public int port { get; set; }
        }
    }
}
