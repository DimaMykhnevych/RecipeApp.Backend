using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.RecipeRepository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task<Recipe> GetRecipeByTitle(string title)
        {
            return await context.Recipes.FirstOrDefaultAsync(r => r.Title.ToLower() == title.ToLower());
        }

        public async Task<IEnumerable<Recipe>> GetRecipesWithNutritionInfo()
        {
            return await context.Recipes
                .Include(r => r.RecipeSteps)
                .AsNoTracking()
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .ThenInclude(i => i.NutrientIngredients)
                .ThenInclude(ni => ni.Nutrient)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
