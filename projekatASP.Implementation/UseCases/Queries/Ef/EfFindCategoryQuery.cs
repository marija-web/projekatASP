using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Queries.Ef
{
    public class EfFindCategoryQuery : EfUseCase, IFindCategoryQuery
    {
        public EfFindCategoryQuery(ProjekatDbContext context) : base(context)
        {
                
        }

        public int Id => 1;

        public string Name => "Ef find Category";

        public string Description => "This Ef is finding one category through requested id.";

        public CategoryDTO Execute(int sentRequest)
        {
            var id = sentRequest;
            var category = Context.Category.Find(id);  

            if(category == null)
            {
                throw new EntityNotFoundE(nameof(Category), id);
            }

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}

