using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.DTO
{
    public class EditUseCasesDTO
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
