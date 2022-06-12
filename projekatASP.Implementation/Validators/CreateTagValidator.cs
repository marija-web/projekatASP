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
    public class CreateTagValidator : AbstractValidator<TagDTO>
    {
        private ProjekatDbContext _context;

        public CreateTagValidator(ProjekatDbContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                              .NotEmpty().WithMessage("Tag name is required!")
                              .MinimumLength(2).WithMessage("Name can not be less then 2 letters!")
                              .Must(TagNameTaken).WithMessage("Name {PropertyValue} is already taken!");
            _context =context;
        }
        private bool TagNameTaken(string name)
        {
            var taken = _context.Tag.Any(x => x.Name == name);

            return !taken;
        }

    }
}
