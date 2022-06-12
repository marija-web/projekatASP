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
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private CreateCategoryValidator _validator;

        public EfCreateCategoryCommand(ProjekatDbContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Ef create category";

        public string Description => "This Ef is creating category";

        public void Execute(CreateCategoryDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var category = new Category
            {
                Name = sentRequest.Name
            };

            Context.Category.Add(category);
            Context.SaveChanges();
        }
    }
}
