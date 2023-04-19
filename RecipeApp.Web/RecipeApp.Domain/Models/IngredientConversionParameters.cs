namespace RecipeApp.Domain.Models
{
    public class IngredientConversionParameters
    {
        public string IngredientName { get; set; }
        public double SourceAmount { get; set; }
        public string SourceUnit { get; set; }
        public string TargetUnit { get; set; }
    }
}
