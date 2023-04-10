using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class RecipeDto
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

        public ICollection<RecipeStepDto> RecipeSteps { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}
