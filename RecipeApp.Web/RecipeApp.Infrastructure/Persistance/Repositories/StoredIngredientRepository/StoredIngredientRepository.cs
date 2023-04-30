using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.StoredIngredientRepository
{
    public class StoredIngredientRepository : Repository<StoredIngredient>, IStoredIngredientRepository
    {
        public StoredIngredientRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task AddOrUpdateStoredIngredient(StoredIngredient storedIngredient)
        {
            StoredIngredient existingStoredIngredient =
                await context.StoredIngredients
                .FirstOrDefaultAsync(si => si.IngredientId == storedIngredient.IngredientId
                                        && si.AppUserId == storedIngredient.AppUserId);
            if (existingStoredIngredient == null)
            {
                await Insert(storedIngredient);
                return;
            }

            existingStoredIngredient.ExpirationDate = storedIngredient.ExpirationDate;
            existingStoredIngredient.Amount = storedIngredient.Amount;
            existingStoredIngredient.LastModifiedDate = DateTime.Now;
            await Update(existingStoredIngredient);
        }

        public async Task<IEnumerable<StoredIngredient>> GetExpiredStoredIngredientsWithUserInfo()
        {
            return await context.StoredIngredients
                .Include(si => si.AppUser)
                .AsNoTracking()
                .Include(si => si.Ingredient)
                .AsNoTracking()
                .Where(si => si.ExpirationDate <= DateTime.Now.AddDays(1))
                .ToListAsync();
        }

        public async Task<IEnumerable<StoredIngredient>> GetUserStoredIngredientsWithIngredientsInfo(int userId)
        {
            return await context.StoredIngredients
                .Include(si => si.Ingredient)
                .AsNoTracking()
                .Where(si => si.AppUserId == userId)
                .ToListAsync();
        }
    }
}
