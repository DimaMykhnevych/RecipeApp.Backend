using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Models
{
    public class RecipesMatchingResult
    {
        public IEnumerable<Recipe> FilteredRecipes { get; set; }
        public Dictionary<int, double> RecipesMatchingPercentage { get; set; }
    }
}
