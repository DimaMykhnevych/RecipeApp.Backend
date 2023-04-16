using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.StoredIngredientRepository
{
    public interface IStoredIngredientRepository : IRepository<StoredIngredient>
    {
        Task<IEnumerable<StoredIngredient>> GetUserStoredIngredientsWithIngredientsInfo(int userId);
        Task AddOrUpdateStoredIngredient(StoredIngredient storedIngredient);
    }
}
