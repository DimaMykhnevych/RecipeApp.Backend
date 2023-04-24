using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Builders
{
    public class MealPlanQueryBuilder : IMealPlanQueryBuilder
    {
        private readonly RecipeAppDbContext _dbContext;
        private IQueryable<MealPlan> _query;

        public MealPlanQueryBuilder(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MealPlan> Build()
        {
            IQueryable<MealPlan> result = _query;
            _query = null;
            return result;
        }

        public IMealPlanQueryBuilder SetBaseMealPlanInfo()
        {
            _query = _dbContext.MealPlans
                .Include(mp => mp.MealPlanDays)
                .ThenInclude(mpd => mpd.Ingestion)
                .AsNoTracking()
                .Include(mp => mp.MealPlanDays)
                .ThenInclude(mpd => mpd.Recipe)
                .ThenInclude(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .AsNoTracking()
                .Include(mp => mp.MealPlanDays)
                .ThenInclude(mpd => mpd.Recipe)
                .ThenInclude(r => r.RecipeSteps);

            return this;
        }

        public IMealPlanQueryBuilder SetFamilyId(int? id)
        {
            if (id != null)
            {
                _query = _query.Where(mp => mp.FamilyId == id);
            }

            return this;
        }

        public IMealPlanQueryBuilder SetId(int? id)
        {
            if (id != null)
            {
                _query = _query.Where(mp => mp.Id == id);
            }

            return this;
        }

        public IMealPlanQueryBuilder SetAppUserId(int? id)
        {
            if (id != null)
            {
                _query = _query.Where(mp => mp.AppUserId == id);
            }

            return this;
        }
    }
}
