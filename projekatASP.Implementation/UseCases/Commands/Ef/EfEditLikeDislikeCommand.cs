using FluentValidation;
using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.DataAccess;
using projekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Commands.Ef
{
    public class EfEditLikeDislikeCommand : EfUseCase, IEditLikeDislikeCommand
    {
        private CreateLikeDislikeValidator _validator;

        public EfEditLikeDislikeCommand(ProjekatDbContext context, CreateLikeDislikeValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 26;

        public string Name => "Ef edit like/dislike";

        public string Description => "This Ef is editing one like/dislike through requested id.";

        public void Execute(LikeDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var likeDislike = Context.LikeDislike.Find(sentRequest.PostId, sentRequest.UserId);

            if (likeDislike == null)
            {
                throw new EntityNotFoundE(nameof(likeDislike), sentRequest.PostId);
            }

            likeDislike.Like = sentRequest.Like;
            likeDislike.UserId = sentRequest.UserId;
            likeDislike.PostId = sentRequest.PostId;
            Context.SaveChanges();
        }
    }
}
