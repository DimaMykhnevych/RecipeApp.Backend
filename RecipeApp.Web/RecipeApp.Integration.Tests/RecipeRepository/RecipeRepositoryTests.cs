using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Repositories.RecipeRepository;
using RecipeApp.Integration.Tests.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RecipeApp.Integration.Tests.RecipeRepositoryN
{
    public class RecipeRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        private SharedDatabaseFixture fixture { get; }

        public RecipeRepositoryTests(SharedDatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task GetRecipes_ReturnsAllRecipes()
        {
            using var context = fixture.CreateContext();
            var repository = new RecipeRepository(context);
            var recipes = await repository.GetAll();
            Assert.Equal(10, recipes.Count());
        }

        [Fact]
        public async Task GetRecipeByTitle_ReturnsMatchedRecipe()
        {
            using var context = fixture.CreateContext();
            var repository = new RecipeRepository(context);
            var searchedRecipeTitle = "Recipe 3";
            var recipe = await repository.GetRecipeByTitle(searchedRecipeTitle);
            Assert.NotNull(recipe);
            Assert.Equal(searchedRecipeTitle, recipe.Title);
        }

        [Fact]
        public async Task CreateRecipe_SavesCorrectData()
        {
            Recipe recipeToCreate = new()
            {
                Title = "IntegrationTestRecipe",
                Image = "testRecipe.jpg",
                Carbs = 120,
                Fat = 123,
                Protein = 89.3,
                Calories = 3445.12,
                ReadyInMinutes = 12,
                Servings = 3,
                Vegan = false,
                Healthy = true,
                Season = Season.DemiSeason,
                Summary = "IntegrationTestRecipe summary",
                DishType = DishType.Breakfast,
                RecipeIngredients = new List<RecipeIngredient>()
                {
                    new()
                    {
                        Amount = 12.34,
                        Ingredient = new()
                        {
                            Name = "TestIngredient",
                            Unit = Unit.Grams
                        }
                    }
                }
            };

            using var context = fixture.CreateContext();
            var repository = new RecipeRepository(context);
            var addedRecipe = await repository.Insert(recipeToCreate);
            await repository.Save();

            repository = new RecipeRepository(context);
            var recipe = await repository.GetRecipeWithIngredientsInfo(addedRecipe.Id);
            Assert.NotNull(recipe);
            Assert.Equal(recipeToCreate.Title, recipe.Title);
            Assert.Equal(recipeToCreate.Image, recipe.Image);
            Assert.Equal(recipeToCreate.Carbs, recipe.Carbs);
            Assert.Equal(recipeToCreate.Fat, recipe.Fat);
            Assert.Equal(recipeToCreate.Protein, recipe.Protein);
            Assert.Equal(recipeToCreate.Calories, recipe.Calories);
            Assert.Equal(recipeToCreate.ReadyInMinutes, recipe.ReadyInMinutes);
            Assert.Equal(recipeToCreate.Servings, recipe.Servings);
            Assert.Equal(recipeToCreate.Vegan, recipe.Vegan);
            Assert.Equal(recipeToCreate.Healthy, recipe.Healthy);
            Assert.Equal(recipeToCreate.Season, recipe.Season);
            Assert.Equal(recipeToCreate.Summary, recipe.Summary);
            Assert.Equal(recipeToCreate.DishType, recipe.DishType);
            Assert.Equal(recipeToCreate.RecipeIngredients.Count, recipe.RecipeIngredients.Count);

            var recipeIngredientToAdd = recipeToCreate.RecipeIngredients.First();
            var addedRecipeIngredient = recipe.RecipeIngredients.First();

            Assert.Equal(recipeIngredientToAdd.Amount, addedRecipeIngredient.Amount);
            Assert.Equal(recipeIngredientToAdd.Ingredient.Name, addedRecipeIngredient.Ingredient.Name);
            Assert.Equal(recipeIngredientToAdd.Ingredient.Unit, addedRecipeIngredient.Ingredient.Unit);
        }

        [Fact]
        public async Task UpdateRecipe_SavesCorrectData()
        {
            var recipeId = 1;
            Recipe recipeToUpdate = new()
            {
                Id = recipeId,
                Title = "UpdatedTitle",
                Calories = 12
            };

            using var context = fixture.CreateContext();
            var repository = new RecipeRepository(context);
            await repository.Update(recipeToUpdate);
            await repository.Save();

            var updatedRecipe = await repository.Get(recipeId);
            Assert.NotNull(updatedRecipe);
            Assert.Equal(recipeToUpdate.Title, updatedRecipe.Title);
            Assert.Equal(recipeToUpdate.Calories, updatedRecipe.Calories);
        }

        [Fact]
        public async Task DeleteRecipeById_EnsuresRecipeIsDeleted()
        {
            var recipeId = 5;
            using var context = fixture.CreateContext();
            var repository = new RecipeRepository(context);
            await repository.DeleteById(recipeId);
            await repository.Save();

            var recipes = await repository.GetAll();
            Assert.Equal(9, recipes.Count());

            var deletedRecipe = await repository.Get(recipeId);
            Assert.Null(deletedRecipe);
        }
    }
}
