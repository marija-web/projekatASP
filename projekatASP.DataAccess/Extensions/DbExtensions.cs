using projekatASP.DataAccess.Exceptions;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projekatASP.DataAccess.Extensions
{
    public static class DbExtensions
    {
        public static IApplicationUser User { get; }

        public static void Deactivate<T>(this ProjekatDbContext context, int id)
            where T : Entity
        {
            var itemsForSF = context.Set<T>().Find(id);

            if(itemsForSF == null)
            {
                throw new EntityNotFoundE(nameof(T), id);
            }

            itemsForSF.DeletedBy = User?.Identity;
            itemsForSF.DeletedAt = DateTime.UtcNow;
            itemsForSF.IsActive = false;
        }

        public static void DeactivateArray<T>(this ProjekatDbContext context, IEnumerable<int> ids)
         where T : Entity
        {
            var toDeactivate = context.Set<T>().Where(x => ids.Contains(x.Id));

            foreach (var t in toDeactivate)
            {
                t.DeletedBy = User?.Identity;
                t.IsActive = false;
                t.DeletedAt = DateTime.UtcNow;
            }

        }
    }
}
