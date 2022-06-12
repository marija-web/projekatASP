using projekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.Queries
{
    public interface IFindCategoryQuery : IQuery<int, CategoryDTO>
    {
    }
}
