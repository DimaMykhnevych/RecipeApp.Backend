namespace RecipeApp.Domain.Services.Recipe.AddRecipeNutritionService
{
    public interface IAddRecipeNutritionService
    {
        Task AddRecipeNutrition(int? recipeId);
    }
}
