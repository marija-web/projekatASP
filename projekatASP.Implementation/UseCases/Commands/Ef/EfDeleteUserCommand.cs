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
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 15;

        public string Name => "Ef delete user";

        public string Description => "This Ef is deleteing one user through requested id.";

        public void Execute(int sentRequest)
        {
            var id = sentRequest;
            var user = Context.User.Include(x=>x.Comments).Include(x=>x.LikeDislikes)
                                   .ThenInclude(x=>x.Post).FirstOrDefault(x=>x.Id == id && x.IsActive);

            if (user == null)
            {
                throw new EntityNotFoundE(nameof(User), sentRequest);
            }

            var postId = Context.Post.Where(x => x.UserId == id).Select(x=>x.Id);
            var commentId = Context.Comment.Where(x => x.UserId == id).Select(x=>x.Id);

            Context.Deactivate<User>(id);     
            Context.DeactivateArray<Post>(postId);
            Context.DeactivateArray<Comment>(commentId);

            Context.SaveChanges();
        }
    }
}
