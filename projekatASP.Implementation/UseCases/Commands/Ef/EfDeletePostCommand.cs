using Microsoft.EntityFrameworkCore;
using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.Commands;
using projekatASP.DataAccess;
using projekatASP.DataAccess.Extensions;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Commands.Ef
{
    public class EfDeletePostCommand : EfUseCase, IDeletePostCommand
    {
        public EfDeletePostCommand(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 17;

        public string Name => "Ef delete post";

        public string Description => "This Ef is deleteing one post through requested id.";

        public void Execute(int sentRequest)
        {
            var id = sentRequest;
            var post = Context.Post.Include(x => x.User).Include(x => x.LikeDislikes).Include(x => x.Comments)
                        .Include(x => x.Category).Include(x => x.PostImages).ThenInclude(x => x.Image)
                        .Include(x => x.PostTags).ThenInclude(x => x.Tag).FirstOrDefault(x => x.Id == id && x.IsActive);

            if (post == null)
            {
                throw new EntityNotFoundE(nameof(Post), sentRequest);
            }

            var commentId = Context.Comment.Where(x => x.PostId == id).Select(x => x.Id);

            Context.Deactivate<Post>(sentRequest);
            Context.DeactivateArray<Comment>(commentId);
            Context.SaveChanges();
        }
    }
}
