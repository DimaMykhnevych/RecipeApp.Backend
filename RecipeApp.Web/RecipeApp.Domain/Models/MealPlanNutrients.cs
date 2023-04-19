namespace RecipeApp.Domain.Models
{
    public class MealPlanNutrients
    {
        public IEnumerable<int> RecipeIds { get; set; }
        public IEnumerable<RecipeNutrient> Nutrients { get; set; }
    }
}
