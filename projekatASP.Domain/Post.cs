using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Caprtion { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
        public ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<LikeDislike> LikeDislikes { get; set; } = new List<LikeDislike>();
    }
}
