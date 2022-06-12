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
    public class CreatePostValidator : AbstractValidator<CreatePostDTO>
    {
        private ProjekatDbContext _context;

        public CreatePostValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Title).Cascade(CascadeMode.Stop)
                              .NotEmpty().WithMessage("Title is required!")
                              .MinimumLength(4).WithMessage("Title can not be less then 4 letters!");

            RuleFor(x => x.Caption).Cascade(CascadeMode.Stop)
                              .NotEmpty().WithMessage("Caption is required!")
                              .MinimumLength(10).WithMessage("Caption can not be less then 10 letters!");

            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop)
                             .NotEmpty().WithMessage("User id is required!")
                             .Must(IdTakenUser).WithMessage("User must exist!");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                             .NotEmpty().WithMessage("CategoryId is required!")
                             .Must(IdTakenCategory).WithMessage("Category must exist!");

            RuleFor(x => x.TagId).NotEmpty().WithMessage("TagId is required!");

            RuleForEach(x => x.TagId.Select(y=>y)).Cascade(CascadeMode.Stop)
                                                  .NotEmpty().WithMessage("TagId is required!")
                                                  .Must(IdTakenTag).When(z => z.TagId != null).WithMessage("Tag must exist!")
                                                  .OverridePropertyName("tags");
           

            _context = context;
        }

        private bool IdTakenUser(int id)
        {
            var takenId = true;
            if (!_context.User.Any(x => x.Id == id && x.IsActive))
            {
                takenId = false;
            }
            return takenId;
        }

        private bool IdTakenCategory(int id)
        {
            var takenId = true;
            if (!_context.Category.Any(x => x.Id == id && x.IsActive))
            {
                takenId = false;
            }
            return takenId;
        }

        private bool IdTakenTag(int id)
        {
            var tagExist = _context.Tag.Any(x => x.Id == id && x.IsActive);

            return tagExist;
        }
    }
}
