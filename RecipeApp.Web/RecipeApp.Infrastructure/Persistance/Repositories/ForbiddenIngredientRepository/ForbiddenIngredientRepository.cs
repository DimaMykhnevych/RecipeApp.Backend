using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.ForbiddenIngredientRepository
{
    public class ForbiddenIngredientRepository : Repository<ForbiddenIngredient>, IForbiddenIngredientRepository
    {
        public ForbiddenIngredientRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
