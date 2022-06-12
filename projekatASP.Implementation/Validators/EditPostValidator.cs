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
    public class EditPostValidator : AbstractValidator<CreatePostDTO>
    {
        private ProjekatDbContext _context;

        public EditPostValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Title).MinimumLength(4).WithMessage("Title can not be less then 4 letters!");

            RuleFor(x => x.Caption).MinimumLength(10).WithMessage("Caption can not be less then 10 letters!");

            RuleFor(x => x.UserId).Must(IdTakenUser).When(x=>x.UserId != 0).WithMessage("User must exist!");

            RuleFor(x => x.CategoryId).Must(IdTakenCategory).When(x => x.CategoryId != 0).WithMessage("Category must exist!");

            RuleForEach(x => x.TagId.Select(y => y)).Must(IdTakenTag).When(z=>z.TagId != null).WithMessage("Tag must exist!")
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
            var tageExist = _context.Tag.Any(x => x.Id == id && x.IsActive);

            return tageExist;
        }
    }
}
