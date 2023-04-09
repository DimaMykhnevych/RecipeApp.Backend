using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.RecipeRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> GetRecipeByTitle(string title);
    }
}
