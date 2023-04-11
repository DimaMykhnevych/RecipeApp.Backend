using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.IngredientRepository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task<Ingredient> GetIngredientByName(string name)
        {
            return await context.Ingredients.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        public async Task<ICollection<Ingredient>> GetIngredients(string ingredientName)
        {
            if (string.IsNullOrEmpty(ingredientName))
            {
                return await context.Ingredients.ToListAsync();
            }

            return await context.Ingredients
                .Where(i => i.Name.ToLower().Contains(ingredientName.ToLower()))
                .ToListAsync();
        }
    }
}
