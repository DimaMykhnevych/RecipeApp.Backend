using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.ForbiddenNutrientRepository
{
    public interface IForbiddenNutrientRepository : IRepository<ForbiddenNutrient>
    {
        Task<IEnumerable<ForbiddenNutrient>> GetUserForbiddenNutrients(int externalUserId);
    }
}
