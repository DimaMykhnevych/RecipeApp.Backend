using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Models
{
    public class SetStoredIngredients
    {
        public int UserId { get; set; }
        public IEnumerable<Recipe> FilteredRecipes { get; set; }
        public bool? ConsiderIngredientsAmount { get; set; }
        public double? AcceptableMatchIngredientsPercentage { get; set; }
    }
}
