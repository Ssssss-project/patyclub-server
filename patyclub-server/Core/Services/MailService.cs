using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;
using MimeKit;
using System.Collections.Generic;

namespace patyclub_server.Core.Service
{
    public class MailUser{
        public MailUser(string _userName, string _mailAddress) {
            userName = userName;
            mailAddress = _mailAddress;
        }
        public string userName {get; set;}
        public string mailAddress {get; set;}
    }
    public class MailService
    {
        public MimeMessage Mail(List<MailUser> ToList, string mailTitle, string body)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("PATYCLUB", "patyclub9453@gmail.com"));
            foreach (var To in ToList)
            {
                message.To.Add(new MailboxAddress(To.userName, To.mailAddress));
            }
            

            message.Subject = mailTitle;
            message.Body = new TextPart ("plain") {
				Text = body
			};

            return message;
        }

        public MimeMessage HTMLMail(List<MailUser> ToList, string mailTitle, string body)
        {
            var builder = new BodyBuilder();
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("PATYCLUB", "patyclub9453@gmail.com"));
            foreach (var To in ToList)
            {
                message.To.Add(new MailboxAddress(To.userName, To.mailAddress));
            }
            

            message.Subject = mailTitle;
            builder.HtmlBody = body;

            message.Body = builder.ToMessageBody();

            return message;
        }


        public void sendMail(MimeMessage message){
			using (var client = new SmtpClient ()) {
				client.Connect ("smtp.gmail.com", 465, true);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate ("patyclub9453@gmail.com", "paty-9748");
                client.Send (message);
				client.Disconnect (true);
			}
        }

        public void sendMail(List<MimeMessage> messageList){
			using (var client = new SmtpClient ()) {
				client.Connect ("smtp.gmail.com", 465, true);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate ("patyclub9453@gmail.com", "paty-9748");

                foreach (var message in messageList)
                {
                    client.Send (message);
                }
				client.Disconnect (true);
			}
        }
    }
    
}