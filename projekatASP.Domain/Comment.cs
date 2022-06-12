using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Domain
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
