using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.ForbiddenNutrientN.UpdateForbiddenNutrientService
{
    public interface IUpdateForbiddenNutrientService
    {
        Task<bool> UpdateForbiddenNutrientAsync(int appUserId, ForbiddenNutrient forbiddenNutrient);
    }
}
