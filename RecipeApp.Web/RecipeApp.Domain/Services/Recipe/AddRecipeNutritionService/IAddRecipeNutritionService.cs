namespace RecipeApp.Domain.Services.RecipeN.AddRecipeNutritionService
{
    public interface IAddRecipeNutritionService
    {
        Task AddRecipeNutrition(int? recipeId);
    }
}
