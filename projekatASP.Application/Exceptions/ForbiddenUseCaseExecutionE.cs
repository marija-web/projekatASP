using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.Exceptions
{
    public class ForbiddenUseCaseExecutionE : Exception
    {
        public ForbiddenUseCaseExecutionE(string useCase, string user) :
            base($"User {user} has tried to execute {useCase} without being authorized.")
        {

        }
    }
}
