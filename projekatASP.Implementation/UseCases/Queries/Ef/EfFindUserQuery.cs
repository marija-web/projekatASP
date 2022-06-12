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
    public class EfFindUserQuery : EfUseCase, IFindUserQuery
    {
        public EfFindUserQuery(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 13;

        public string Name => "Ef find user";

        public string Description => "This Ef is finding one user through requested id.";

        public RegisterDTO Execute(int sentRequest)
        {
            var id = sentRequest;
            var user = Context.User.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundE(nameof(User), id);
            }

            return new RegisterDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName=user.LastName,
                Username=user.Username,
                Email=user.Email,
                Password=user.Password
            };
        }
    }
}
