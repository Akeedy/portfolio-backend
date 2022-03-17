
using MailKit.Net.Smtp;
using MimeKit;

namespace portfolio_backend.EmailService  {
    public class EmailSender:IEmailSender{

        public EmailConfiguration _emailConfiguration ;
        public EmailSender(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration=emailConfiguration;
        }


        void IEmailSender.SendEmail(Message message)
        {

            var emailMessage=CreateEmailMessage(message);
            Send(emailMessage);
        }


        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage=new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject=message.Subject;
            emailMessage.Body=new TextPart(MimeKit.Text.TextFormat.Html){
                Text=String.Format("<h3>{0}</h3></br><p>{1}</p>",message.Subject,message.Content)
            };

            return emailMessage;

        }
        private void Send(MimeMessage emailMessage)
        {
            using (var client=new SmtpClient()){
                try
                {
                    client.Connect(_emailConfiguration.SmtpServer,_emailConfiguration.Port);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.UserName,_emailConfiguration.Password);
                    client.Send(emailMessage);

                }
                catch 
                {
                    throw;
                }
                finally{
                        client.Disconnect(true);
                        client.Dispose();
                }
            }
        }
    }
}