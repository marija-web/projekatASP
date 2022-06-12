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
    public class EfEditTagCommand : EfUseCase, IEditTagCommand
    {
        private CreateTagValidator _validator;

        public EfEditTagCommand(ProjekatDbContext context, CreateTagValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 9;

        public string Name => "Ef edit tag";

        public string Description => "This Ef is editing one tag through requested id.";

        public void Execute(TagDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var tag = Context.Tag.Find(sentRequest.Id);

            if (tag == null)
            {
                throw new EntityNotFoundE(nameof(Tag), sentRequest.Id);
            }

            tag.Name = sentRequest.Name;
            Context.SaveChanges();
        }
    }
}
