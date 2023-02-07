using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Persistance.Context
{
    public class RecipeAppDbContext : IdentityDbContext<AppUser, UserRole, Guid>
    {
        public RecipeAppDbContext(DbContextOptions<RecipeAppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
