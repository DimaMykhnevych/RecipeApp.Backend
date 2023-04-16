using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Builders
{
    public interface IRecipeQueryBuilder : IQueryBuilder<Recipe>
    {
        IRecipeQueryBuilder SetBaseRecipeInfo();
        IRecipeQueryBuilder SetId(int? id);
        IRecipeQueryBuilder SetTitle(string title);
        IRecipeQueryBuilder SetCalories(double? fromCalories, double? toCalories);
        IRecipeQueryBuilder SetCarbs(double? fromCarbs, double? toCarbs);
        IRecipeQueryBuilder SetFat(double? fromFat, double? toFat);
        IRecipeQueryBuilder SetProtein(double? fromProtein, double? toProtein);
        IRecipeQueryBuilder SetReadyInMinutes(double? fromMinutes, double? toMinutes);
        IRecipeQueryBuilder SetVegan(bool? isVegan);
        IRecipeQueryBuilder SetHealthy(bool? isHealthy);
        IRecipeQueryBuilder SetSeason(Season? season);
        IRecipeQueryBuilder SetDishType(DishType? dishType);
        IRecipeQueryBuilder SetExcludeIngredients(IEnumerable<int> ingredientIds);
    }
}
