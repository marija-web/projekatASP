using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }
        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Email { get; set; }
    }

    public class AnonimousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 11 };

        public string Email => "userAnonimous@aspProject.com";
    }
}
