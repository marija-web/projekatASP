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
    public class EditCommentValidator : AbstractValidator<CreateCommentForPostDTO>
    {
        private ProjekatDbContext _context;

        public EditCommentValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Comment).MinimumLength(1).WithMessage("Comment can not be less then 1 letters!");

            RuleFor(x => x.PostId).Must(IdTakenPost).WithMessage("Post must exist!");

            RuleFor(x => x.UserId).Must(IdTakenUser).WithMessage("User must exist!");
            
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
