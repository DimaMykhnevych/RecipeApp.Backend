using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ForbiddenNutrient>> GetUserForbiddenNutrients(int externalUserId)
        {
            return await context.ForbiddenNutrients
                .Include(dn => dn.Nutrient)
                .AsNoTracking()
                .Include(fn => fn.ExternalUser)
                .AsNoTracking()
                .Where(fn => fn.ExternalUserId == externalUserId)
                .ToListAsync();
        }
    }
}
