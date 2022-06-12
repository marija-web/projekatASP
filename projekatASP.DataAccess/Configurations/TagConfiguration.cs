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
    public class TagConfiguration : EntityConfiguration<Tag>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);

            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.PostTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
