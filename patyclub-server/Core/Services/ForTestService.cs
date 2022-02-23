using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;
using MimeKit;

namespace patyclub_server.Core.Service
{
    public class TestService
    {
        public string concateTTT(string a, string b)
        {
            return a + b;
        }

        public void sendMail()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("PTC SERVER", "patyclub9453@gmail.com"));
            message.To.Add(new MailboxAddress("TEST CLIENT", "charles01270@gmail.com"));

            message.Subject = "How you doing?";
            message.Body = new TextPart ("plain") {
				Text = @"Hey Chandler,

                    I just wanted to let you know that Monica and I were going to go play some paintball, you in?

                    -- Joey"
			};


			using (var client = new SmtpClient ()) {
				client.Connect ("smtp.gmail.com", 465, true);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate ("patyclub9453@gmail.com", "paty-9748");

				client.Send (message);
				client.Disconnect (true);
			}
        }
    }
    
}