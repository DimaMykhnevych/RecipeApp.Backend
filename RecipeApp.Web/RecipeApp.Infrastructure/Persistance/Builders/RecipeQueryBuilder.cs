using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Builders
{
    public class RecipeQueryBuilder : IRecipeQueryBuilder
    {
        private readonly RecipeAppDbContext _dbContext;
        private IQueryable<Recipe> _query;

        public RecipeQueryBuilder(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Recipe> Build()
        {
            IQueryable<Recipe> result = _query;
            _query = null;
            return result;
        }

        public IRecipeQueryBuilder SetBaseRecipeInfo()
        {
            _query = _dbContext.Recipes
                .Include(r => r.RecipeSteps)
                .AsNoTracking()
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .AsNoTracking();
            return this;
        }

        public IRecipeQueryBuilder SetCalories(double? fromCalories, double? toCalories)
        {
            if (fromCalories == null && toCalories != null)
            {
                _query = _query.Where(j => j.Calories <= toCalories);
            }
            else if (toCalories == null && fromCalories != null)
            {
                _query = _query.Where(j => j.Calories >= fromCalories);
            }
            else if (fromCalories != null && toCalories != null)
            {
                _query = _query.Where(j => j.Calories >= fromCalories && j.Calories <= toCalories);
            }
            return this;
        }

        public IRecipeQueryBuilder SetCarbs(double? fromCarbs, double? toCarbs)
        {
            if (fromCarbs == null && toCarbs != null)
            {
                _query = _query.Where(j => j.Carbs <= toCarbs);
            }
            else if (toCarbs == null && fromCarbs != null)
            {
                _query = _query.Where(j => j.Carbs >= fromCarbs);
            }
            else if (fromCarbs != null && toCarbs != null)
            {
                _query = _query.Where(j => j.Carbs >= fromCarbs && j.Carbs <= toCarbs);
            }
            return this;
        }

        public IRecipeQueryBuilder SetDishType(DishType? dishType)
        {
            if (dishType != null)
            {
                _query = _query.Where(r => r.DishType == dishType);
            }
            return this;
        }

        public IRecipeQueryBuilder SetExcludeIngredients(IEnumerable<int> ingredientIds)
        {
            if (ingredientIds != null && ingredientIds.Any())
            {
                _query = _query.Where(r => r.RecipeIngredients.All(ri => !ingredientIds.Contains(ri.IngredientId)));
            }

            return this;
        }

        public IRecipeQueryBuilder SetFat(double? fromFat, double? toFat)
        {
            if (fromFat == null && toFat != null)
            {
                _query = _query.Where(j => j.Fat <= toFat);
            }
            else if (toFat == null && fromFat != null)
            {
                _query = _query.Where(j => j.Fat >= fromFat);
            }
            else if (fromFat != null && toFat != null)
            {
                _query = _query.Where(j => j.Fat >= fromFat && j.Fat <= toFat);
            }
            return this;
        }

        public IRecipeQueryBuilder SetHealthy(bool? isHealthy)
        {
            if (isHealthy != null)
            {
                _query = _query.Where(r => r.Healthy == isHealthy);
            }
            return this;
        }

        public IRecipeQueryBuilder SetId(int? id)
        {
            if (id != null)
            {
                _query = _query.Where(r => r.Id == id);
            }
            return this;
        }

        public IRecipeQueryBuilder SetProtein(double? fromProtein, double? toProtein)
        {
            if (fromProtein == null && toProtein != null)
            {
                _query = _query.Where(j => j.Protein <= toProtein);
            }
            else if (toProtein == null && fromProtein != null)
            {
                _query = _query.Where(j => j.Protein >= fromProtein);
            }
            else if (fromProtein != null && toProtein != null)
            {
                _query = _query.Where(j => j.Protein >= fromProtein && j.Protein <= toProtein);
            }
            return this;
        }

        public IRecipeQueryBuilder SetReadyInMinutes(double? fromMinutes, double? toMinutes)
        {
            if (fromMinutes == null && toMinutes != null)
            {
                _query = _query.Where(j => j.ReadyInMinutes <= toMinutes);
            }
            else if (toMinutes == null && fromMinutes != null)
            {
                _query = _query.Where(j => j.ReadyInMinutes >= fromMinutes);
            }
            else if (fromMinutes != null && toMinutes != null)
            {
                _query = _query.Where(j => j.ReadyInMinutes >= fromMinutes && j.ReadyInMinutes <= toMinutes);
            }
            return this;
        }

        public IRecipeQueryBuilder SetSeason(Season? season)
        {
            if (season != null)
            {
                _query = _query.Where(r => r.Season == season);
            }
            return this;
        }

        public IRecipeQueryBuilder SetTitle(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _query = _query.Where(r => r.Title.ToLower().Contains(title.ToLower()));
            }
            return this;
        }

        public IRecipeQueryBuilder SetVegan(bool? isVegan)
        {
            if (isVegan != null)
            {
                _query = _query.Where(r => r.Vegan == isVegan);
            }
            return this;
        }
    }
}
