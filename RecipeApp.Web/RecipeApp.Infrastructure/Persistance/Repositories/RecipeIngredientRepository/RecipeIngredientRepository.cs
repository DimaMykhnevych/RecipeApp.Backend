using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.RecipeIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.RecipeIngredientRepository
{
    public class RecipeIngredientRepository : Repository<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
