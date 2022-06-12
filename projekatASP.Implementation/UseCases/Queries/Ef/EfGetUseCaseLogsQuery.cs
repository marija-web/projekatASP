using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using projekatASP.Application.UseCases;
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
    public class EfGetUseCaseLogsQuery : EfUseCase, IGetUseCaseLogsQuery
    {
        public EfGetUseCaseLogsQuery(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 20;

        public string Name => "Ef search use cse logs";

        public string Description => "This Ef is searching through all use case logs.";

        public PaginationShow<UseCaseLogDTO> Execute(MainPaginationSearch sentRequest)
        {
            var keyword = sentRequest.Keyword;
            var page = sentRequest.Page;
            var perPage = sentRequest.PerPage;
            var query = Context.UseCaseLogs.Include(x=>x.User).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.UseCaseName.Contains(keyword) || x.User.LastName.Contains(keyword) ||
                                    x.User.LastName.Contains(keyword));
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

            var pagination = new PaginationShow<UseCaseLogDTO>();

            pagination.CountAll = query.Count();

            pagination.Data = query.Skip(toSkip).Take(perPage.Value).Select(x => new UseCaseLogDTO
            {
                Id = x.Id,
                UseCaseName = x.UseCaseName,
                UserId = x.UserId,
                ExecutionDateTime = x.ExecutionDateTime,
                Data = x.Data,
                IsAuthorized = x.IsAuthorized
            }).ToList();

            pagination.CurrentPage = page.Value;
            pagination.ItemsPerPage = perPage.Value;

            return pagination;
        }
    }
}
