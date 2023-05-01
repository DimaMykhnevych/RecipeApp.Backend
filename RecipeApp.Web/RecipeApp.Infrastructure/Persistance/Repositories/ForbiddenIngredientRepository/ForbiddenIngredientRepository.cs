using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ForbiddenIngredient>> GetUserForbiddenIngredients(int externalUserId)
        {
            return await context.ForbiddenIngredients
                .Where(fi => fi.ExternalUserId == externalUserId)
                .ToListAsync();
        }
    }
}
