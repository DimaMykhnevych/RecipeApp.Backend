using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Context;
using System;
using System.Data.Common;

namespace RecipeApp.Integration.Tests.Base
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;
        private readonly IConfiguration _configuration;
        public SharedDatabaseFixture()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();
            Connection = new MySqlConnection(_configuration.GetConnectionString("Default"));
            Seed();
            Connection.Open();
        }

        public DbConnection Connection { get; }

        public RecipeAppDbContext CreateContext(DbTransaction? transaction = null)
        {
            var connectionString = _configuration.GetConnectionString("Default");
            var context = new RecipeAppDbContext(
                new DbContextOptionsBuilder<RecipeAppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options);
            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();

                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    SeedData(context);

                    _databaseInitialized = true;
                }
            }
        }
        private void SeedData(RecipeAppDbContext context)
        {
            var recipeIds = 1;
            var fakeRecipes = new Faker<Recipe>()
                .RuleFor(o => o.Title, f => $"Recipe {recipeIds}")
                .RuleFor(o => o.Image, f => $"Image {recipeIds}")
                .RuleFor(o => o.Id, f => recipeIds++)
                .RuleFor(o => o.Calories, f => f.Random.Double(0.01, 4000))
                .RuleFor(o => o.Carbs, f => f.Random.Double(0.01, 200))
                .RuleFor(o => o.Protein, f => f.Random.Double(0.01, 200))
                .RuleFor(o => o.Fat, f => f.Random.Double(0.01, 200))
                .RuleFor(o => o.ReadyInMinutes, f => f.Random.Double(0.01, 200))
                .RuleFor(o => o.Vegan, f => f.Random.Bool())
                .RuleFor(o => o.Healthy, f => f.Random.Bool())
                .RuleFor(o => o.Season, f => (Season)f.Random.Number(0, 4))
                .RuleFor(o => o.Servings, f => f.Random.Number(1, 8))
                .RuleFor(o => o.Summary, f => $"Summary {recipeIds}")
                .RuleFor(o => o.DishType, f => (DishType)f.Random.Number(0, 4));

            var products = fakeRecipes.Generate(10);
            context.AddRange(products);
            context.SaveChanges();
        }
        public void Dispose() => Connection.Dispose();
    }
}
