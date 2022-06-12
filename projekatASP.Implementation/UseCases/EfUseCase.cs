using projekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(ProjekatDbContext context)
        {
            Context = context;
        }

        protected ProjekatDbContext Context { get; }
    }
}