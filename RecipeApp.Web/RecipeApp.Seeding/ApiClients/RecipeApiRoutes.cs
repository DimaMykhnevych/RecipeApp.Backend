namespace RecipeApp.Seeding.ApiClients
{
    internal static class RecipeApiRoutes
    {
        public const string GetRecipeById = "https://api.spoonacular.com/recipes/{id}/information?includeNutrition=true";
        public const string GetIngredientById = "https://api.spoonacular.com/food/ingredients/{id}/information?amount={amount}&unit={unit}";
        public const string ConvertUnit = "https://api.spoonacular.com/recipes/convert?ingredientName={ingredientName}&sourceAmount={sourceAmount}&sourceUnit={sourceUnit}&targetUnit={targetUnit}";
    }
}
