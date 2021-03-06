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
    public class RegisterUserValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterUserValidator(ProjekatDbContext context)
        {
            //Email
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Email is not in a good format!")
                .Must(x => !context.User.Any(y => y.Email == x)).WithMessage("Email address {PropertyValue} is already in use. Type another one!");

            //Username
            RuleFor(x => x.Username)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Username is required!")
               .MinimumLength(4).WithMessage("Username can not be less then 4 letters!")
               .MaximumLength(11).WithMessage("Username can not have more then 11 letters!")
               .Matches("^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$")
               .WithMessage("Username is not in a good format!")
               .Must(x => !context.User.Any(u => u.Username == x)).WithMessage("Username {PropertyValue} is already in use. Type another one!");

            var nameLastnameRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";
            //FirstName
            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required!")
                .Matches(nameLastnameRegex).WithMessage("First name is not in a good format!");

            //LastName
            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required!")
                .Matches(nameLastnameRegex).WithMessage("Last name is not in a good format!");

            //Password
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!")
                .Matches(@"^.{6,}$")
                  .WithMessage("Password must contain minimum 6 in lenght!");

        }
    }
}
