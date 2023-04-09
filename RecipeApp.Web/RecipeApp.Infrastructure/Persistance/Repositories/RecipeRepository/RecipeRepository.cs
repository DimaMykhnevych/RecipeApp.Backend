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
    }
}
