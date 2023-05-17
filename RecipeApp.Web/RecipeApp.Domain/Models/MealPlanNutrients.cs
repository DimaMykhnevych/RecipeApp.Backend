namespace RecipeApp.Domain.Models
{
    public class MealPlanNutrients
    {
        public IEnumerable<int> RecipeIds { get; set; }
        public IEnumerable<RecipeNutrient> Nutrients { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
    }
}
