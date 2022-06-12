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
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        private ProjekatDbContext _context;

        public CreateCategoryValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                              .NotEmpty().WithMessage("Category name is required!")
                              .MinimumLength(2).WithMessage("Name can not be less then 2 letters!")
                              .Must(CategoryNameTaken).WithMessage("Name {PropertyValue} is already taken!");
            _context = context;
        }

        private bool CategoryNameTaken(string name)
        {
            var taken = _context.Category.Any(x => x.Name == name);

            return !taken;
        }
    }

}
