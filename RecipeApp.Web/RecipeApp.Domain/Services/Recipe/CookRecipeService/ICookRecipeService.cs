namespace RecipeApp.Domain.Services.RecipeN.CookRecipeService
{
    public interface ICookRecipeService
    {
        Task<bool> CookRecipeAsync(int appUserId, int recipeId);
    }
}
