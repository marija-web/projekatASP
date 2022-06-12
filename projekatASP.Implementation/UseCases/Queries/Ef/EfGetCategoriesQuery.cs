using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.DTO.Searches;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Queries.Ef
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 2;

        public string Name => "Ef search categories";

        public string Description => "This Ef is searching through all categories.";

        public PaginationShow<CategoryDTO> Execute(MainPaginationSearch sentRequest)
        {
            var keyword = sentRequest.Keyword;
            var page = sentRequest.Page;
            var perPage = sentRequest.PerPage;
            var query = Context.Category.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            if (perPage == null || perPage < 1)
            {
                perPage = 1;
            }

            if (page == null || page < 1)
            {
                perPage = 1;
            }

            var toSkip = (page.Value - 1) * perPage.Value;

            var pagination = new PaginationShow<CategoryDTO>();

            pagination.CountAll = query.Count();

            pagination.Data = query.Skip(toSkip).Take(perPage.Value).Select(x => new CategoryDTO
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();

            pagination.CurrentPage = page.Value;
            pagination.ItemsPerPage = perPage.Value;

            return pagination;
        }
    }
}
