using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.Exceptions
{
    public class EntityNotFoundE : Exception
    {
        public EntityNotFoundE(string type, int id)
            : base($"Entity of type {type} with an id of {id} was not found.")
        {

        }
    }
}
