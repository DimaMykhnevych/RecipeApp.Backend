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

        public async Task<IEnumerable<NutrientRecipe>> GetRecipeNutrients()
        {
            return await context.NutrientRecipes
                .Include(x => x.Nutrient)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> NutrientsForRecipeExist(int recipeId)
        {
            var nutrientsExist = await context.NutrientRecipes
                .AnyAsync(nr => nr.RecipeId == recipeId);

            return nutrientsExist;
        }
    }
}
