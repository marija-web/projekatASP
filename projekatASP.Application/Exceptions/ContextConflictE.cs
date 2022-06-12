using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.Exceptions
{
    public class ContextConflictE : Exception
    {
        public ContextConflictE(string message) : base(message)
        {

        }
    }
}
