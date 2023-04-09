using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.NutrientIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.NutrientIngredientRepository
{
    public class NutrientIngredientRepository : Repository<NutrientIngredient>, INutrientIngredientRepository
    {
        public NutrientIngredientRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
