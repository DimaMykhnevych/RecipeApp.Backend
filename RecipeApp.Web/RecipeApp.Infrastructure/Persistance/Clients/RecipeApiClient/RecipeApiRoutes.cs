namespace RecipeApp.Infrastructure.Persistance.Clients.RecipeApiClient
{
    public class RecipeApiRoutes
    {
        public const string ConvertUnit = "https://api.spoonacular.com/recipes/convert?ingredientName={ingredientName}&sourceAmount={sourceAmount}&sourceUnit={sourceUnit}&targetUnit={targetUnit}";
    }
}
