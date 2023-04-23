using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.NutrientRecipeRepository
{
    public interface INutrientRecipeRepository : IRepository<NutrientRecipe>
    {
        Task<IEnumerable<NutrientRecipe>> GetRecipeNutrients();
        Task<bool> NutrientsForRecipeExist(int recipeId);
    }
}
