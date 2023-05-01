using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.ForbiddenIngredientN.AddForbiddenIngredientService
{
    public interface IAddForbiddenIngredientService
    {
        Task<bool> AddForbiddenIngredientAsync(int appUserId, ForbiddenIngredient forbiddenIngredient);
    }
}
