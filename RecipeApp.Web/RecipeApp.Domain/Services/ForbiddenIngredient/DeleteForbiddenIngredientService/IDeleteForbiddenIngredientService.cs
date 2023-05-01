namespace RecipeApp.Domain.Services.ForbiddenIngredientN.DeleteForbiddenIngredientService
{
    public interface IDeleteForbiddenIngredientService
    {
        Task<bool> DeleteForbiddenIngredientAsync(int appUserId, int forbiddenIngredientId);
    }
}
