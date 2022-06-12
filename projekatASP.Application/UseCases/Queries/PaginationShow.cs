using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.Queries
{
    public class PaginationShow<T> where T : class
    {
        public int CountAll { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int CountPages => (int)Math.Ceiling((float)CountAll / ItemsPerPage);
        public IEnumerable<T> Data { get; set; }
    }
}
