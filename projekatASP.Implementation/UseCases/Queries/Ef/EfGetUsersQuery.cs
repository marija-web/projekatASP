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
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 12;

        public string Name => "Ef search users";

        public string Description => "This Ef is searching through all users.";

        public PaginationShow<RegisterDTO> Execute(MainPaginationSearch sentRequest)
        {
            var keyword = sentRequest.Keyword;
            var page = sentRequest.Page;
            var perPage = sentRequest.PerPage;
            var query = Context.User.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword) || 
                                    x.Username.Contains(keyword) || x.Email.Contains(keyword));
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

            var pagination = new PaginationShow<RegisterDTO>();

            pagination.CountAll = query.Count();

            pagination.Data = query.Skip(toSkip).Take(perPage.Value).Select(x => new RegisterDTO
            {
                Id = x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Email=x.Email,
                Password=x.Password
            }).ToList();

            pagination.CurrentPage = page.Value;
            pagination.ItemsPerPage = perPage.Value;

            return pagination;
        }
    }
}
