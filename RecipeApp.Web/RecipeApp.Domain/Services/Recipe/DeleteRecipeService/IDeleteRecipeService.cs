namespace RecipeApp.Domain.Services.RecipeN.DeleteRecipeService
{
    public interface IDeleteRecipeService
    {
        Task<bool> DeleteRecipeAsync(int recipeId, int appUserId);
    }
}
