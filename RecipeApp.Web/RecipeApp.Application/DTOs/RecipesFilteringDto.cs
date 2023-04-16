using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class RecipesFilteringDto
    {
        public int? RecipeId { get; set; }
        public string Title { get; set; }
        public double? FromCalories { get; set; }
        public double? ToCalories { get; set; }
        public double? FromCarbs { get; set; }
        public double? ToCarbs { get; set; }
        public double? FromFat { get; set; }
        public double? ToFat { get; set; }
        public double? FromProtein { get; set; }
        public double? ToProtein { get; set; }
        public double? FromReadyInMinutes { get; set; }
        public double? ToReadyInMinutes { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsHealthy { get; set; }
        public Season? Season { get; set; }
        public DishType? DishType { get; set; }
        public bool? UseCurrentlyStoredIngredients { get; set; }
        public bool? ExcludeForbiddenIngredients { get; set; }
        public bool? ConsiderIngredientsAmount { get; set; }
    }
}
