using RecipeApp.Domain.Entities;
using System.Collections.Generic;

namespace RecipeApp.Unit.Tests.Builders.RecipeQueryBuilderN
{
    public class TestDataHelper
    {
        public static List<Recipe> GetFakeRecipesList()
        {
            return new List<Recipe>()
            {
                new ()
                {
                    Title = "TestRecipe 1",
                    Image = "testRecipe 1.jpg",
                    Carbs = 140,
                    Fat = 123,
                    Protein = 89.3,
                    Calories = 3445.12,
                    ReadyInMinutes = 12,
                    Servings = 3,
                    Vegan = false,
                    Healthy = true,
                    Season = Season.DemiSeason,
                    Summary = "TestRecipe summary 1",
                    DishType = DishType.Dinner,
                    AppUserId = 1
                },
                new ()
                {
                    Title = "TestRecipe 2",
                    Image = "testRecipe 2.jpg",
                    Carbs = 120,
                    Fat = 123,
                    Protein = 89.3,
                    Calories = 2445.12,
                    ReadyInMinutes = 12,
                    Servings = 3,
                    Vegan = false,
                    Healthy = true,
                    Season = Season.DemiSeason,
                    Summary = "TestRecipe summary 2",
                    DishType = DishType.Breakfast,
                    AppUserId = 2
                },
                new ()
                {
                    Title = "TestRecipe 3",
                    Image = "testRecipe 3.jpg",
                    Carbs = 80,
                    Fat = 123,
                    Protein = 89.3,
                    Calories = 2300.12,
                    ReadyInMinutes = 12,
                    Servings = 3,
                    Vegan = false,
                    Healthy = true,
                    Season = Season.DemiSeason,
                    Summary = "TestRecipe summary 3",
                    DishType = DishType.Lunch
                }
            };
        }
    }
}
