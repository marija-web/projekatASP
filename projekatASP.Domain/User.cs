using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<LikeDislike> LikeDislikes { get; set; } = new List<LikeDislike>();
        public ICollection<UserUseCase> UseCases { get; set; } = new List<UserUseCase>();
        public ICollection<UseCaseLogs> UseCaseLogs { get; set; } = new List<UseCaseLogs>();
    }
}
