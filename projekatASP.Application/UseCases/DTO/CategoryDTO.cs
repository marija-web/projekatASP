using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.DTO
{
    public class CategoryDTO : MainDTO
    {
        public string Name { get; set; }
    }

    public class CreateCategoryDTO :MainDTO
    {
        public string Name { get; set; }
    }

}
