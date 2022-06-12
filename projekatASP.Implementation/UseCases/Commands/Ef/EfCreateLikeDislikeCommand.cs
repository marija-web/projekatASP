using FluentValidation;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.DataAccess;
using projekatASP.Domain;
using projekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Commands.Ef
{
    public class EfCreateLikeDislikeCommand : EfUseCase, ICreateLikeDislikeCommand
    {
        private CreateLikeDislikeValidator _validator;

        public EfCreateLikeDislikeCommand(ProjekatDbContext context, CreateLikeDislikeValidator validator) :base(context)
        {
            _validator = validator;
        }
        public int Id => 24;

        public string Name => "Ef create like";

        public string Description => "This Ef is creating like";

        public void Execute(LikeDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var likeDislike = new LikeDislike
            {
                PostId=sentRequest.PostId,
                UserId=sentRequest.UserId,
                Like=sentRequest.Like
            };

            Context.LikeDislike.Add(likeDislike);
            Context.SaveChanges();
        }
    }
}
