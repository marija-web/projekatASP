using FluentValidation;
using projekatASP.Application.Emails;
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
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmail _email;
        public EfRegisterUserCommand(ProjekatDbContext context, RegisterUserValidator validator, IEmail email) : base(context)
        {
            _validator = validator;
            _email = email;
        }
        public int Id => 11;

        public string Name => "Ef register user";

        public string Description => "This Ef is registering one user into the database.";

        public void Execute(RegisterDTO sentRequest)
        {
            var password = sentRequest.Password;
            _validator.ValidateAndThrow(sentRequest);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Email = sentRequest.Email,
                Username = sentRequest.Username,
                FirstName = sentRequest.FirstName,
                LastName = sentRequest.LastName,
                Password = passwordHash
            };

            Context.User.Add(user);
            Context.SaveChanges();

            _email.SendEmail(new EmailMessage
            {
                To=sentRequest.Email,
                Title="You have successfully registered. Welcome!",
                Body="Hi " + sentRequest.Username + ".Please activate your account."
            });
        }
    }
}
