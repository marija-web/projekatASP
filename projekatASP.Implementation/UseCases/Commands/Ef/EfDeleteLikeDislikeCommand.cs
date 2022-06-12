using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
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
    public class EfDeleteLikeDislikeCommand : EfUseCase, IDeleteLikeDislikeCommand
    {

        public EfDeleteLikeDislikeCommand(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 25;

        public string Name => "Ef delete like/dislike";

        public string Description => "This Ef is deleteing one like/dislike through requested id.";

        public void Execute(LikeDTO sentRequest)
        {
            var id = sentRequest;
            var likeDislike = Context.LikeDislike.Find(sentRequest.UserId, sentRequest.PostId);

            if (likeDislike == null)
            {
                throw new EntityNotFoundE(nameof(LikeDislike), likeDislike.PostId);
            }
            Context.LikeDislike.Remove(likeDislike);
            Context.SaveChanges();
        }
    }
}
