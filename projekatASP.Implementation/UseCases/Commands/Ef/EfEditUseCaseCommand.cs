using FluentValidation;
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
    public class EfEditUseCaseCommand : EfUseCase, IEditUserCaseCommand
    {
        private EditUseCaseValidator _validator;
        public EfEditUseCaseCommand(ProjekatDbContext context, EditUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 19;

        public string Name => "Ef edit use case";

        public string Description => "This Ef is editing one use case through requested id.";

        public void Execute(EditUseCasesDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var userUseCases = Context.UserUseCases.Where(x => x.UserId == sentRequest.UserId).ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            var newUserUseCase = sentRequest.UseCaseIds.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = sentRequest.UserId
            });

            Context.UserUseCases.AddRange(newUserUseCase);

            Context.SaveChanges();
        }
    }
}
