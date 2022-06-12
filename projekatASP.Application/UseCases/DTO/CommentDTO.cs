using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.DTO
{
    public class CreateCommentForPostDTO : MainDTO
    {
        public string Comment { get; set; }
        public int PostId{ get; set; }
        public int UserId{ get; set; }
    }
}
