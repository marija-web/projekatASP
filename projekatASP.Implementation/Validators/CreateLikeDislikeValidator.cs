using FluentValidation;
using projekatASP.Application.UseCases.DTO;
using projekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.Validators
{
    public class CreateLikeDislikeValidator : AbstractValidator<LikeDTO>
    {
        private ProjekatDbContext _context;

        public CreateLikeDislikeValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Like).NotEmpty().When(y => y.Like != false && y.Like != true).WithMessage("Like is required!");

            RuleFor(x => x.PostId).Cascade(CascadeMode.Stop)
                            .NotEmpty().WithMessage("Post id is required!")
                            .Must(IdTakenPost).WithMessage("Post must exist!");


            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop)
                            .NotEmpty().WithMessage("User id is required!")
                            .Must(IdTakenUser).WithMessage("User must exist!");

            _context = context;
        }

        private bool IdTakenPost(int id)
        {
            var postExist = _context.Post.Any(x => x.Id == id && x.IsActive);

            return postExist;
        }

        private bool IdTakenUser(int id)
        {
            var userExist = _context.User.Any(x => x.Id == id && x.IsActive);

            return userExist;
        }
    }
}
