﻿using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.RecipeRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> GetRecipeByTitle(string title);
        Task<IEnumerable<Recipe>> GetRecipesWithNutritionInfo();
        Task<Recipe> GetRecipeWithNutritionInfo(int id);
        Task<Recipe> GetRecipeWithIngredientsInfo(int id);
    }
}
