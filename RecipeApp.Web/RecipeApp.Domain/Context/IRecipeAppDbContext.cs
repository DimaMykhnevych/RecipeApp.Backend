using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Context
{
    public interface IRecipeAppDbContext
    {
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<ExternalUser> ExternalUsers { get; set; }
        DbSet<Family> Families { get; set; }
        DbSet<FamilyMember> FamilyMembers { get; set; }
        DbSet<MealPlan> MealPlans { get; set; }
        DbSet<Ingestion> Ingestions { get; set; }
        DbSet<MealPlanDay> MealPlanDays { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeStep> RecipeSteps { get; set; }
        DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<StoredIngredient> StoredIngredients { get; set; }
        DbSet<Nutrient> Nutrients { get; set; }
        DbSet<NutrientIngredient> NutrientIngredients { get; set; }
        DbSet<NutrientRecipe> NutrientRecipes { get; set; }
        DbSet<ForbiddenNutrient> ForbiddenNutrients { get; set; }
        DbSet<ForbiddenIngredient> ForbiddenIngredients { get; set; }
    }
}
