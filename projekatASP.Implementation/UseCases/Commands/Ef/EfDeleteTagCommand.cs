using Microsoft.EntityFrameworkCore;
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
    public class EfDeleteTagCommand : EfUseCase, IDeleteTagCommand
    {
        public EfDeleteTagCommand(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 10;

        public string Name => "Ef delete tag";

        public string Description => "This Ef is deleteing one tag through requested id.";

        public void Execute(int sentRequest)
        {
            var id = sentRequest;
            var tag = Context.Tag.Find(id);

            if (tag == null)
            {
                throw new EntityNotFoundE(nameof(Tag), sentRequest);
            }

            Context.Deactivate<Tag>(sentRequest);
            Context.SaveChanges();
        }
    }
}
