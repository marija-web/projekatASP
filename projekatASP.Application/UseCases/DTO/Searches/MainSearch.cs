using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.DTO.Searches
{
    public class MainSearch
    {
        public string Keyword { get; set; }
    }

    public class PaginationSearch
    {
        public int? PerPage { get; set; } = 1;
        public int? Page { get; set; } = 1;
    }

    public class MainPaginationSearch : PaginationSearch
    {
        public string Keyword { get; set; }
    }
}
