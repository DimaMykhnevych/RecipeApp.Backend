using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.ForbiddenNutrientRepository
{
    public class ForbiddenNutrientRepository : Repository<ForbiddenNutrient>, IForbiddenNutrientRepository
    {
        public ForbiddenNutrientRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
