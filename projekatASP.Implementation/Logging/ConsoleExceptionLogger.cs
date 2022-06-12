using projekatASP.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Happend at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
        }
    }
}
