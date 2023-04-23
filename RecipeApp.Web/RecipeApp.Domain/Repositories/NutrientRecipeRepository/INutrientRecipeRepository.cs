using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.NutrientRecipeRepository
{
    public interface INutrientRecipeRepository : IRepository<NutrientRecipe>
    {
        Task<bool> NutrientRecipeExists(int recipeId, int nutrientId);
        Task<bool> NutrientsForRecipeExist(int recipeId);
    }
}
