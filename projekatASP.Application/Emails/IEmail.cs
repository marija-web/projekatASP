using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.Emails
{
    public interface IEmail
    {
        void SendEmail(EmailMessage message);
    }
}
