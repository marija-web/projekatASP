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
    public class EfCreateTagCommand : EfUseCase, ICreateTagCommand
    {
        private CreateTagValidator _validator;
        public EfCreateTagCommand(ProjekatDbContext context, CreateTagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Ef create tag";

        public string Description => "This Ef is creating tag";

        public void Execute(TagDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var tag = new Tag
            {
                Name = sentRequest.Name
            };

            Context.Tag.Add(tag);
            Context.SaveChanges();
        }
    }
}
