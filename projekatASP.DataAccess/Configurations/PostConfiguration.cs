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
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Caprtion).HasMaxLength(500).IsRequired();

            builder.HasIndex(x => x.Title);

            builder.HasMany(x => x.PostTags).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.PostImages).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.LikeDislikes).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
