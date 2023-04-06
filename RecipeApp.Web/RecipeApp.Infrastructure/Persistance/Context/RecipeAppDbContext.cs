using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Persistance.Context
{
    public class RecipeAppDbContext : IdentityDbContext<AppUser, UserRole, int>
    {
        public RecipeAppDbContext(DbContextOptions<RecipeAppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ExternalUser> ExternalUsers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .HasOne(c => c.User)
                .WithOne(a => a.AppUser)
                .HasForeignKey<ExternalUser>(c => c.AppUserId);

            base.OnModelCreating(builder);
        }
    }
}
