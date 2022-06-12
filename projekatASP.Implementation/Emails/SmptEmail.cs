using projekatASP.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.Emails
{
    public class SmptEmail : IEmail
    {
        private readonly string _email;
        private readonly string _password;
        private int _port;
        private string _host;

        public SmptEmail(string email, string password, int port, string host)
        {
            _email = email;
            _password = password;
            _port = port;
            _host = host;
        }

        public void SendEmail(EmailMessage message)
        {
            var smtp = new SmtpClient
            {
                Host = _host,
                Port = _port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_email, _password), 
                UseDefaultCredentials=false
            };

            var messageEmail = new MailMessage(_email, message.To);
            messageEmail.Subject = message.Title;
            messageEmail.Body = message.Body;
            messageEmail.IsBodyHtml = true;

            smtp.Send(messageEmail);
        }
    }
}
