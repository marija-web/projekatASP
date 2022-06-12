using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Queries.Ef
{
    public class EfFindTagQuery : EfUseCase, IFindTagQuery
    {
        public EfFindTagQuery(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 7;

        public string Name => "Ef find Tag";

        public string Description => "This Ef is finding one tag through requested id.";

        public TagDTO Execute(int sentRequest)
        {
            var id = sentRequest;
            var tag = Context.Tag.Find(id);

            if (tag == null)
            {
                throw new EntityNotFoundE(nameof(Tag), id);
            }

            return new TagDTO
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
