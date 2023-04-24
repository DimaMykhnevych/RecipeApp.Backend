using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Builders
{
    public interface IMealPlanQueryBuilder : IQueryBuilder<MealPlan>
    {
        IMealPlanQueryBuilder SetBaseMealPlanInfo();
        IMealPlanQueryBuilder SetId(int? id);
        IMealPlanQueryBuilder SetFamilyId(int? id);
        IMealPlanQueryBuilder SetAppUserId(int? id);
    }
}
