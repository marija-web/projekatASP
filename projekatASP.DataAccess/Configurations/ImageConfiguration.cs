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
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).HasMaxLength(100);

            builder.HasMany(x => x.PostImages).WithOne(x => x.Image).HasForeignKey(x => x.ImageId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
