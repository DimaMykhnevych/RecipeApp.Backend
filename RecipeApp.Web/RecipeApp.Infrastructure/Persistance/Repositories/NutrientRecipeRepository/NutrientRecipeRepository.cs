using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.NutrientRecipeRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.NutrientRecipeRepository
{
    public class NutrientRecipeRepository : Repository<NutrientRecipe>, INutrientRecipeRepository
    {
        public NutrientRecipeRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task<bool> NutrientRecipeExists(int recipeId, int nutrientId)
        {
            var nutrient = await context.NutrientRecipes
                .FirstOrDefaultAsync(nr => nr.RecipeId == recipeId && nr.NutrientId == nutrientId);

            return nutrient != null;
        }

        public async Task<bool> NutrientsForRecipeExist(int recipeId)
        {
            var nutrientsExist = await context.NutrientRecipes
                .AnyAsync(nr => nr.RecipeId == recipeId);

            return nutrientsExist;
        }
    }
}
