using projekatASP.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.Api.Emails
{
    public class EmailTest : IEmail
    {
        public void SendEmail(EmailMessage message)
        {
            System.Console.WriteLine("Sending email:");
            System.Console.WriteLine("To: " + message.To);
            System.Console.WriteLine("Title: " + message.Title);
            System.Console.WriteLine("Body: " + message.Body);
        }
    }
}
