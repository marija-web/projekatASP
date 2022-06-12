using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.Commands;
using projekatASP.DataAccess;
using projekatASP.DataAccess.Extensions;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Commands.Ef
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 3;

        public string Name => "Ef delete category";

        public string Description => "This Ef is deleteing one category through requested id.";

        public void Execute(int sentRequest)
        {
            var id = sentRequest;
            var category = Context.Category.Find(id);

            if(category == null){
                throw new EntityNotFoundE(nameof(Category), sentRequest);
            }

            if(category.Posts.Any())
            {
                throw new ContextConflictE("Can't delete category because it is linked to posts");
            }


            Context.Deactivate<Category>(sentRequest);
            Context.SaveChanges();
        }
    }
}
