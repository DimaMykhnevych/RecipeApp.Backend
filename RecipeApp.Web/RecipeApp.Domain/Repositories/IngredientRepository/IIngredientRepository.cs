using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.IngredientRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<ICollection<Ingredient>> GetIngredients(string ingredientName);
        Task<Ingredient> GetIngredientByName(string name);
    }
}
