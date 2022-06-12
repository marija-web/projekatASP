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
    public class EditUseCaseValidator : AbstractValidator<EditUseCasesDTO>
    {
        private ProjekatDbContext _context;

        public EditUseCaseValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.UserId).Cascade(CascadeMode.Stop)
                                  .NotEmpty().WithMessage("User is required.")
                                  .Must(x => context.User.Any(u => u.Id == x)).WithMessage("User does not exist.");

            RuleFor(x => x.UseCaseIds).Cascade(CascadeMode.Stop)
                                      .NotEmpty().WithMessage("Use cases are required.")
                                      .Must(x => x.Count() == x.Distinct().Count()).WithMessage("Duplicate values are not allowed.");
            _context = context;
        }
    }
}
