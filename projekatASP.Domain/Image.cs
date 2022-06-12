using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Domain
{
    public class Image : Entity
    {
        public string Path { get; set; }
        public ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
    }
}
