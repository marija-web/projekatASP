using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.DataAccess.Configurations
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Posts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
