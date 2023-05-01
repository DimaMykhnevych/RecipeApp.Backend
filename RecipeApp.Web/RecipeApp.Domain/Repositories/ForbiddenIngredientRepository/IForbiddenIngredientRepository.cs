using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.ForbiddenIngredientRepository
{
    public interface IForbiddenIngredientRepository : IRepository<ForbiddenIngredient>
    {
        Task<IEnumerable<ForbiddenIngredient>> GetUserForbiddenIngredients(int externalUserId);
    }
}
