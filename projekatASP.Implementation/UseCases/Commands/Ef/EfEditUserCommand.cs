using FluentValidation;
using projekatASP.Application.Exceptions;
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
    public class EfEditUserCommand : EfUseCase, IEditUserCommand
    {
        private EditUserValidator _validator;

        public EfEditUserCommand(ProjekatDbContext context, EditUserValidator validator) : base(context)
        {
            _validator = validator;
        }


        public int Id => 14;

        public string Name => "Ef edit user";

        public string Description => "This Ef is editing one user through requested id.";

        public void Execute(RegisterDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var user = Context.User.Find(sentRequest.Id);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(sentRequest.Password);

            if (user == null)
            {
                throw new EntityNotFoundE(nameof(User), sentRequest.Id);
            }

            if (sentRequest.FirstName != null)
            {
                user.FirstName = sentRequest.FirstName;
            }

            if (sentRequest.LastName != null)
            {
                user.LastName = sentRequest.LastName;
            }

            if (sentRequest.Password != null)
            {
                user.Password = passwordHash;
            }

            if (sentRequest.Email != null)
            {
                user.Email = sentRequest.Email;
            }

            if (sentRequest.Username != null)
            {
                user.Username = sentRequest.Username;
            }

            Context.SaveChanges();
        }
    }
}
