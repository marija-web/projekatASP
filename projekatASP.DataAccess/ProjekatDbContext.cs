using Microsoft.EntityFrameworkCore;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.DataAccess
{
    public class ProjekatDbContext : DbContext
    {
        //public ProjekatDbContext(DbContextOptions o = null) : base(o)
        //{

        //}
        public IApplicationUser ApplicationUser { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });
            modelBuilder.Entity<PostImage>().HasKey(x => new { x.PostId, x.ImageId });
            modelBuilder.Entity<LikeDislike>().HasKey(x => new { x.PostId, x.UserId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6301J50\SQLEXPRESS;Initial Catalog=projekatASP;Integrated Security=True");
        }


        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = ApplicationUser?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<PostImage> PostImage { get; set; }
        public DbSet<LikeDislike> LikeDislike { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLogs> UseCaseLogs { get; set; }
    }
}
