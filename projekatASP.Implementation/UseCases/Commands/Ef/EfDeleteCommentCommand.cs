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
    public class EfDeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {

        public EfDeleteCommentCommand(ProjekatDbContext context):base(context)
        {

        }

        public int Id => 22;

        public string Name => "Ef delete comment";

        public string Description => "This Ef is deleteing one comment through requested id.";

        public void Execute(int sentRequest)
        {
            var id = sentRequest;
            var comment = Context.Comment.Find(id);

            if (comment == null)
            {
                throw new EntityNotFoundE(nameof(Comment), sentRequest);
            }

            Context.Deactivate<Comment>(sentRequest);
            Context.SaveChanges();
        }
    }
}
