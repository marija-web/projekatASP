using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.Logging
{
    public class ConsoleELogging : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Happened at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
        }
    }
}
