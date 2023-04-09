namespace RecipeApp.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double ReadyInMinutes { get; set; }
        public bool Vegan { get; set; }
        public bool Healthy { get; set; }
        public Season? Season { get; set; }
        public int Servings { get; set; }
        public string Summary { get; set; }
        public DishType DishType { get; set; }

        public ICollection<MealPlanDay> MealPlanDays { get; set; }
        public ICollection<RecipeStep> RecipeSteps { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
