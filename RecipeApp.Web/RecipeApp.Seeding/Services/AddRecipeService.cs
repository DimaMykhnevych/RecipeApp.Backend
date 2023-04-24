using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.Recipe.AddRecipeNutritionService;
using RecipeApp.Seeding.ApiClients;
using RecipeApp.Seeding.ApiModels;

namespace RecipeApp.Seeding.Services
{
    internal class AddRecipeService
    {
        private readonly IRecipeApiClient _recipeApiClient;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly INutrientRepository _nutrientRepository;
        private readonly IAddRecipeNutritionService _addRecipeNutritionService;
        public AddRecipeService(
            IRecipeApiClient recipeApiClient,
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository,
            INutrientRepository nutrientRepository,
            IAddRecipeNutritionService addRecipeNutritionService)
        {
            _recipeApiClient = recipeApiClient;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
            _nutrientRepository = nutrientRepository;
            _addRecipeNutritionService = addRecipeNutritionService;
        }

        public async Task AddRecipe(RecipeDto recipeDto)
        {
            if (await IsRecipeAlreadyExists(recipeDto))
            {
                return;
            }

            Recipe recipe = new()
            {
                Title = recipeDto.Title,
                Image = recipeDto.Image,
                Calories = recipeDto.Nutrition.Nutrients.FirstOrDefault(n => n.Name.ToLower() == "Calories".ToLower()).Amount ?? 0,
                Carbs = recipeDto.Nutrition.Nutrients.FirstOrDefault(n => n.Name.ToLower() == "Carbohydrates".ToLower()).Amount ?? 0,
                Fat = recipeDto.Nutrition.Nutrients.FirstOrDefault(n => n.Name.ToLower() == "Fat".ToLower()).Amount ?? 0,
                Protein = recipeDto.Nutrition.Nutrients.FirstOrDefault(n => n.Name.ToLower() == "Protein".ToLower()).Amount ?? 0,
                ReadyInMinutes = recipeDto.ReadyInMinutes ?? 0,
                Vegan = recipeDto.Vegan ?? false,
                Healthy = recipeDto.Healthy ?? false,
                Season = Season.DemiSeason,
                Servings = recipeDto.Servings ?? 1,
                Summary = recipeDto.Summary,
                DishType = GetDishType(recipeDto.DishTypes),
                RecipeSteps = ConvertRecipeStep(recipeDto.AnalyzedInstructions)
            };

            var distinctIngredients = recipeDto.ExtendedIngredients.DistinctBy(c => c.Name);
            recipe.RecipeIngredients = new List<RecipeIngredient>();
            foreach (var ingredient in distinctIngredients)
            {
                var targetUnit = GetIngredientUnit(ingredient);
                var targetAmount = await GetIngredientAmount(ingredient, targetUnit);
                RecipeIngredient recipeIngredient = new()
                {
                    Amount = targetAmount
                };
                var existingIngredient = await _ingredientRepository.GetIngredientByName(ingredient.Name);
                if (existingIngredient != null)
                {
                    recipeIngredient.IngredientId = existingIngredient.Id;
                    recipe.RecipeIngredients.Add(recipeIngredient);
                    continue;
                }

                recipeIngredient.Ingredient = new Ingredient
                {
                    Name = ingredient.Name,
                    Unit = targetUnit
                };

                recipeIngredient.Ingredient.NutrientIngredients = await GetIngredientNutrients(ingredient.Id ?? 1);

                recipe.RecipeIngredients.Add(recipeIngredient);
            }

            var insertedRecipe = await _recipeRepository.Insert(recipe);
            await _recipeRepository.Save();
            await _addRecipeNutritionService.AddRecipeNutrition(insertedRecipe.Id);
        }

        private async Task<List<NutrientIngredient>> GetIngredientNutrients(int ingredientId)
        {
            List<NutrientIngredient> nutrientIngredients = new();
            IngredientDto ingredientWithNutrients = await _recipeApiClient.GetIngredientInfo(ingredientId, 100, "gram");
            foreach (NutrientDto nutrient in ingredientWithNutrients.Nutrition.Nutrients)
            {
                if (SkipNutrient(nutrient))
                {
                    continue;
                }

                NutrientIngredient nutrientIngredient = new()
                {
                    PercentOfDailyNeeds = nutrient.PercentOfDailyNeeds ?? 0,
                    Amount = GetNutrientAmount(nutrient),
                };
                Nutrient existingNutrient = await _nutrientRepository.GetNutrientByName(nutrient.Name);
                if (existingNutrient != null)
                {
                    nutrientIngredient.NutrientId = existingNutrient.Id;
                }
                else
                {
                    var addedNutrient = await _nutrientRepository.Insert(new Nutrient()
                    {
                        Name = nutrient.Name,
                        Unit = GetUnitFromShortString(nutrient.Unit, Unit.Milligrams)
                    });
                    await _nutrientRepository.Save();
                    nutrientIngredient.NutrientId = addedNutrient.Id;
                }

                nutrientIngredients.Add(nutrientIngredient);
            }

            return nutrientIngredients;
        }

        private static List<RecipeStep> ConvertRecipeStep(List<InstructionDto> instructions)
        {
            List<RecipeStep> steps = new();
            foreach (StepDto instruction in instructions.SelectMany(i => i.Steps))
            {
                RecipeStep recipeStep = new()
                {
                    Description = instruction.StepDescription,
                    Order = instruction.Number ?? 1
                };
                steps.Add(recipeStep);
            }

            return steps;
        }

        private async Task<double> GetIngredientAmount(IngredientDto ingredientDto, Unit targetUnit)
        {
            var ingredientUnit = ingredientDto.Measures.Metric.UnitShort.ToLower();
            if (IsOriginalUnitAcceptable(ingredientUnit))
            {
                return ingredientDto.Measures.Metric.Amount ?? 0;
            }

            var response = await _recipeApiClient.Convert(ingredientDto.Name, ingredientDto.Measures.Metric.Amount ?? 0, ingredientDto.Unit, GetUnitShortString(targetUnit));
            return response.TargetAmount ?? 0;
        }

        private async Task<bool> IsRecipeAlreadyExists(RecipeDto recipeDto)
        {
            Recipe recipe = await _recipeRepository.GetRecipeByTitle(recipeDto.Title);
            return recipe != null;
        }

        private static double GetNutrientAmount(NutrientDto nutrientDto)
        {
            var initialAmount = nutrientDto.Amount ?? 0;

            if (IsOriginalUnitAcceptable(nutrientDto.Unit))
            {
                return initialAmount;
            }

            if (nutrientDto.Name.ToLower().Contains("Vitamin".ToLower()) 
                && nutrientDto.Unit.ToLower() == "iu")
            {
                return 0.0003 * initialAmount;
            }

            return 0.0005 * initialAmount;
        }

        private static bool SkipNutrient(NutrientDto nutrient)
        {
            List<string> nutrientsToSkip = new() { "fat", "protein", "carbohydrates", "calories" };
            return nutrientsToSkip.Any(n => nutrient.Name.ToLower().Contains(n)) || nutrient.Amount <= 0;
        }

        private static Unit GetIngredientUnit(IngredientDto ingredientDto)
        {
            var ingredientUnit = ingredientDto.Measures.Metric.UnitShort.ToLower();
            if (IsOriginalUnitAcceptable(ingredientUnit))
            {
                return GetUnitFromShortString(ingredientUnit, Unit.Grams);
            }
            else
            {
                if (ingredientDto.Consistency?.ToUpper() == "LIQUID")
                {
                    return Unit.Milliliters;
                }

                return Unit.Grams;
            }
        }

        private static bool IsOriginalUnitAcceptable(string origUnit)
        {
            List<string> acceptableUnits = new() { "l", "ml", "kg", "g", "mg", "µg" };
            return acceptableUnits.Contains(origUnit);
        }

        private static Unit GetUnitFromShortString(string unit, Unit defaultUnit)
        {
            return unit switch
            {
                "l" => Unit.Liters,
                "ml" => Unit.Milliliters,
                "kg" => Unit.Kilograms,
                "g" => Unit.Grams,
                "mg" => Unit.Milligrams,
                "µg" => Unit.Micrograms,
                _ => defaultUnit,
            };
        }

        private static string GetUnitShortString(Unit unit)
        {
            return unit switch
            {
                Unit.Liters => "l",
                Unit.Milliliters => "ml",
                Unit.Kilograms => "kg",
                Unit.Grams => "g",
                Unit.Milligrams => "mg",
                Unit.Micrograms => "µg",
                _ => "g",
            };
        }

        private static DishType GetDishType(List<string> dishTypes)
        {
            var lowerDishTypes = dishTypes.Select(d => d.ToLower());
            if (lowerDishTypes.Contains("dinner") && lowerDishTypes.Contains("lunch"))
            {
                Random rand = new();
                return rand.Next(0, 2) == 0 ? DishType.Dinner : DishType.Lunch;
            }

            if (lowerDishTypes.Contains("dinner"))
            {
                return DishType.Dinner;
            }

            if (lowerDishTypes.Contains("lunch"))
            {
                return DishType.Lunch;
            }

            if (lowerDishTypes.Contains("side dish") || lowerDishTypes.Contains("starter")
                || lowerDishTypes.Contains("snack") || lowerDishTypes.Contains("appetizer"))
            {
                return DishType.Snack;
            }

            if (lowerDishTypes.Contains("morning meal") || lowerDishTypes.Contains("brunch")
                || lowerDishTypes.Contains("breakfast"))
            {
                return DishType.Breakfast;
            }

            if (lowerDishTypes.Contains("main course") && lowerDishTypes.Contains("main dish"))
            {
                Random rand = new();
                return rand.Next(0, 2) == 0 ? DishType.Dinner : DishType.Lunch;
            }

            return DishType.Any;
        }
    }
}
