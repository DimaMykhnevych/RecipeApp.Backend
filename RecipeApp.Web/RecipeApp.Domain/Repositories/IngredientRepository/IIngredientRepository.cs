using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.IngredientRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<Ingredient> GetIngredientByName(string name);
    }
}
