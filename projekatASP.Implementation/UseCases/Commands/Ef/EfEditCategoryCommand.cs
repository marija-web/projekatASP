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
    public class EfEditCategoryCommand : EfUseCase, IEditCategoryCommand
    {
        private CreateCategoryValidator _validator;

        public EfEditCategoryCommand(ProjekatDbContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Ef edit category";

        public string Description => "This Ef is editing one category through requested id.";

        public void Execute(CreateCategoryDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var category = Context.Category.Find(sentRequest.Id);

            if(category == null)
            {
                throw new EntityNotFoundE(nameof(Category), sentRequest.Id);
            }

            category.Name = sentRequest.Name;
            Context.SaveChanges();
        }
    }
}
