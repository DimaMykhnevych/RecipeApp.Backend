using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Builders;
using RecipeApp.Infrastructure.Persistance.Context;
using System.Linq;

namespace RecipeApp.Unit.Tests.Builders.RecipeQueryBuilderN
{
    public class RecipeQueryBuilderTests
    {
        private Mock<IRecipeAppDbContext> contextMock;

        [SetUp]
        public void Setup()
        {
            contextMock = new Mock<IRecipeAppDbContext>();
            contextMock.Setup<DbSet<Recipe>>(x => x.Recipes)
                .ReturnsDbSet(TestDataHelper.GetFakeRecipesList());
        }

        [Test]
        public void SetRecipeCreatorId_WhenCalled_FilterRecipes()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetRecipeCreatorId(2)
                .Build()
                .ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("TestRecipe 2", result.First().Title);
        }

        [Test]
        public void SetCalories_WhenCalled_FilterRecipes()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetCalories(3000, 4000)
                .Build()
                .ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("TestRecipe 1", result.First().Title);
        }

        [Test]
        public void SetCarbs_WhenCalled_FilterRecipes()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetCarbs(70, 125)
                .Build()
                .ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("TestRecipe 2", result[0].Title);
            Assert.AreEqual("TestRecipe 3", result[1].Title);
        }

        [Test]
        public void SetDishType_WhenCalled_FilterRecipes()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetDishType(DishType.Dinner)
                .Build()
                .ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("TestRecipe 1", result[0].Title);
        }

        [Test]
        public void SetTitle_WhenCalled_FilterRecipes()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetTitle("tReci")
                .Build()
                .ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("TestRecipe 1", result[0].Title);
            Assert.AreEqual("TestRecipe 2", result[1].Title);
            Assert.AreEqual("TestRecipe 3", result[2].Title);
        }

        [Test]
        public void MultipleFilters_WhenCalled_FilterRecipes()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetTitle("tReci")
                .SetDishType(DishType.Lunch)
                .SetCarbs(75, 85)
                .Build()
                .ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("TestRecipe 3", result[0].Title);
        }

        [Test]
        public void MultipleFilters_WhenCalled_ReturnsEmptyList()
        {
            IRecipeQueryBuilder recipeQueryBuilder = new RecipeQueryBuilder(contextMock.Object);
            var result = recipeQueryBuilder
                .SetBaseRecipeInfo()
                .SetTitle("tReci32")
                .SetDishType(DishType.Lunch)
                .SetCarbs(75, 85)
                .Build()
                .ToList();

            Assert.AreEqual(0, result.Count);
        }
    }
}
