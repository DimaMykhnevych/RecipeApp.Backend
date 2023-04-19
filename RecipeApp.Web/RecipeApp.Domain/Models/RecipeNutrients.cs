using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Models
{
    public class RecipeNutrients
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<RecipeNutrient> Nutrients { get; set;}
    }
}
