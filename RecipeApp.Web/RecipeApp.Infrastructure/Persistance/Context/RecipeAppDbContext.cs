using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Persistance.Context
{
    public class RecipeAppDbContext : IdentityDbContext<AppUser, UserRole, int>, IRecipeAppDbContext
    {
        public RecipeAppDbContext(DbContextOptions<RecipeAppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ExternalUser> ExternalUsers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Ingestion> Ingestions { get; set; }
        public DbSet<MealPlanDay> MealPlanDays { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<StoredIngredient> StoredIngredients { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<NutrientIngredient> NutrientIngredients { get; set; }
        public DbSet<NutrientRecipe> NutrientRecipes { get; set; }
        public DbSet<ForbiddenNutrient> ForbiddenNutrients { get; set; }
        public DbSet<ForbiddenIngredient> ForbiddenIngredients { get; set; }

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
