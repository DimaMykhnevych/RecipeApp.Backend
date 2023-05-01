namespace RecipeApp.Domain.Services.ForbiddenNutrientN.DeleteForbiddenNutrientService
{
    public interface IDeleteForbiddenNutrientService
    {
        Task<bool> DeleteForbiddenNutrientAsync(int appUserId, int forbiddenNutrientId);
    }
}
