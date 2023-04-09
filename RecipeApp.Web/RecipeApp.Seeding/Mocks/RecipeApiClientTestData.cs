namespace RecipeApp.Seeding.Mocks
{
    internal static class RecipeApiClientTestData
    {
        public static string RecipeResponse = @"
{
   ""vegetarian"":false,
   ""vegan"":false,
   ""glutenFree"":false,
   ""dairyFree"":false,
   ""veryHealthy"":false,
   ""cheap"":false,
   ""veryPopular"":false,
   ""sustainable"":false,
   ""lowFodmap"":false,
   ""weightWatcherSmartPoints"":13,
   ""gaps"":""no"",
   ""preparationMinutes"":-1,
   ""cookingMinutes"":-1,
   ""aggregateLikes"":8,
   ""healthScore"":14,
   ""creditsText"":""foodista.com"",
   ""sourceName"":""foodista.com"",
   ""pricePerServing"":259.54,
   ""extendedIngredients"":[
      {
         ""id"":1055062,
         ""aisle"":""Meat"",
         ""image"":""chicken-breasts.png"",
         ""consistency"":""SOLID"",
         ""name"":""chicken breast"",
         ""nameClean"":""boneless skinless chicken breast"",
         ""original"":""1 pound skinless, boneless chicken breast"",
         ""originalName"":""skinless, boneless chicken breast"",
         ""amount"":1.0,
         ""unit"":""pound"",
         ""meta"":[
            ""boneless"",
            ""skinless""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":1.0,
               ""unitShort"":""lb"",
               ""unitLong"":""pound""
            },
            ""metric"":{
               ""amount"":453.592,
               ""unitShort"":""g"",
               ""unitLong"":""grams""
            }
         }
      },
      {
         ""id"":10031015,
         ""aisle"":""Produce"",
         ""image"":""chili-peppers-green.jpg"",
         ""consistency"":""SOLID"",
         ""name"":""anaheim chili peppers"",
         ""nameClean"":""anaheim pepper"",
         ""original"":""12 Anaheim green chili peppers"",
         ""originalName"":""Anaheim green chili peppers"",
         ""amount"":12.0,
         ""unit"":"""",
         ""meta"":[
            ""green""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":12.0,
               ""unitShort"":"""",
               ""unitLong"":""""
            },
            ""metric"":{
               ""amount"":12.0,
               ""unitShort"":"""",
               ""unitLong"":""""
            }
         }
      },
      {
         ""id"":1014582,
         ""aisle"":""Oil, Vinegar, Salad Dressing"",
         ""image"":""vegetable-oil.jpg"",
         ""consistency"":""LIQUID"",
         ""name"":""canola oil"",
         ""nameClean"":""canola oil"",
         ""original"":""1/2 cup canola oil for frying"",
         ""originalName"":""canola oil for frying"",
         ""amount"":0.5,
         ""unit"":""cup"",
         ""meta"":[
            ""for frying""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":0.5,
               ""unitShort"":""cups"",
               ""unitLong"":""cups""
            },
            ""metric"":{
               ""amount"":118.294,
               ""unitShort"":""ml"",
               ""unitLong"":""milliliters""
            }
         }
      },
      {
         ""id"":1230,
         ""aisle"":""Milk, Eggs, Other Dairy"",
         ""image"":""buttermilk.jpg"",
         ""consistency"":""SOLID"",
         ""name"":""buttermilk can be used as a substitute"",
         ""nameClean"":""buttermilk"",
         ""original"":""1 quart Suero de Sal (whey) or buttermilk can be used as a substitute"",
         ""originalName"":""Suero de Sal (whey) or buttermilk can be used as a substitute"",
         ""amount"":1.0,
         ""unit"":""quart"",
         ""meta"":[
            ""canned"",
            ""(whey)""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":1.0,
               ""unitShort"":""qt"",
               ""unitLong"":""quart""
            },
            ""metric"":{
               ""amount"":946.353,
               ""unitShort"":""ml"",
               ""unitLong"":""milliliters""
            }
         }
      },
      {
         ""id"":20081,
         ""aisle"":""Baking"",
         ""image"":""flour.png"",
         ""consistency"":""SOLID"",
         ""name"":""flour"",
         ""nameClean"":""wheat flour"",
         ""original"":""2 tablespoons flour"",
         ""originalName"":""flour"",
         ""amount"":2.0,
         ""unit"":""tablespoons"",
         ""meta"":[
            
         ],
         ""measures"":{
            ""us"":{
               ""amount"":2.0,
               ""unitShort"":""Tbsps"",
               ""unitLong"":""Tbsps""
            },
            ""metric"":{
               ""amount"":2.0,
               ""unitShort"":""Tbsps"",
               ""unitLong"":""Tbsps""
            }
         }
      },
      {
         ""id"":10611282,
         ""aisle"":""Produce"",
         ""image"":""white-onion.png"",
         ""consistency"":""SOLID"",
         ""name"":""onion"",
         ""nameClean"":""white onion"",
         ""original"":""1 medium white onion, diced"",
         ""originalName"":""white onion, diced"",
         ""amount"":1.0,
         ""unit"":""medium"",
         ""meta"":[
            ""diced"",
            ""white""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":1.0,
               ""unitShort"":""medium"",
               ""unitLong"":""medium""
            },
            ""metric"":{
               ""amount"":1.0,
               ""unitShort"":""medium"",
               ""unitLong"":""medium""
            }
         }
      },
      {
         ""id"":18363,
         ""aisle"":""Bakery/Bread;Pasta and Rice;Ethnic Foods"",
         ""image"":""flour-tortilla.jpg"",
         ""consistency"":""SOLID"",
         ""name"":""corn tortillas"",
         ""nameClean"":""white corn tortilla"",
         ""original"":""12 to 18 corn tortillas, preferably white"",
         ""originalName"":""corn tortillas, preferably white"",
         ""amount"":12.0,
         ""unit"":"""",
         ""meta"":[
            ""white""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":12.0,
               ""unitShort"":"""",
               ""unitLong"":""""
            },
            ""metric"":{
               ""amount"":12.0,
               ""unitShort"":"""",
               ""unitLong"":""""
            }
         }
      },
      {
         ""id"":1011026,
         ""aisle"":""Cheese"",
         ""image"":""cheddar-cheese.png"",
         ""consistency"":""SOLID"",
         ""name"":""cheese"",
         ""nameClean"":""shredded cheese"",
         ""original"":""1 cup white shredded cheese (Monterey Jack, Azadero or Muenster)"",
         ""originalName"":""white shredded cheese (Monterey Jack, Azadero or Muenster)"",
         ""amount"":1.0,
         ""unit"":""cup"",
         ""meta"":[
            ""shredded"",
            ""white"",
            ""(Monterey Jack, Azadero or Muenster)""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":1.0,
               ""unitShort"":""cup"",
               ""unitLong"":""cup""
            },
            ""metric"":{
               ""amount"":236.588,
               ""unitShort"":""ml"",
               ""unitLong"":""milliliters""
            }
         }
      },
      {
         ""id"":1228,
         ""aisle"":""Cheese"",
         ""image"":""camembert.png"",
         ""consistency"":""SOLID"",
         ""name"":""queso fresco"",
         ""nameClean"":""queso fresco"",
         ""original"":""1/4 queso fresco, crumbled"",
         ""originalName"":""queso fresco, crumbled"",
         ""amount"":0.25,
         ""unit"":"""",
         ""meta"":[
            ""crumbled""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":0.25,
               ""unitShort"":"""",
               ""unitLong"":""""
            },
            ""metric"":{
               ""amount"":0.25,
               ""unitShort"":"""",
               ""unitLong"":""""
            }
         }
      },
      {
         ""id"":1056,
         ""aisle"":""Milk, Eggs, Other Dairy"",
         ""image"":""sour-cream.jpg"",
         ""consistency"":""SOLID"",
         ""name"":""crema"",
         ""nameClean"":""sour cream"",
         ""original"":""1/2 cup crema or sour cream (for sauce and topping)"",
         ""originalName"":""crema or sour cream (for sauce and topping)"",
         ""amount"":0.5,
         ""unit"":""cup"",
         ""meta"":[
            ""sour"",
            ""(for sauce and topping)""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":0.5,
               ""unitShort"":""cups"",
               ""unitLong"":""cups""
            },
            ""metric"":{
               ""amount"":118.294,
               ""unitShort"":""ml"",
               ""unitLong"":""milliliters""
            }
         }
      },
      {
         ""id"":2047,
         ""aisle"":""Spices and Seasonings"",
         ""image"":""salt.jpg"",
         ""consistency"":""SOLID"",
         ""name"":""salt"",
         ""nameClean"":""table salt"",
         ""original"":""Salt (to taste)"",
         ""originalName"":""Salt (to taste)"",
         ""amount"":6.0,
         ""unit"":""servings"",
         ""meta"":[
            ""to taste""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":6.0,
               ""unitShort"":""servings"",
               ""unitLong"":""servings""
            },
            ""metric"":{
               ""amount"":6.0,
               ""unitShort"":""servings"",
               ""unitLong"":""servings""
            }
         }
      },
      {
         ""id"":14412,
         ""aisle"":""Beverages"",
         ""image"":""water.png"",
         ""consistency"":""LIQUID"",
         ""name"":""water"",
         ""nameClean"":""water"",
         ""original"":""Water (if needed)"",
         ""originalName"":""Water (if needed)"",
         ""amount"":6.0,
         ""unit"":""servings"",
         ""meta"":[
            ""(if needed)""
         ],
         ""measures"":{
            ""us"":{
               ""amount"":6.0,
               ""unitShort"":""servings"",
               ""unitLong"":""servings""
            },
            ""metric"":{
               ""amount"":6.0,
               ""unitShort"":""servings"",
               ""unitLong"":""servings""
            }
         }
      }
   ],
   ""id"":642403,
   ""title"":""Enchiladas Verdes (Green Enchiladas)"",
   ""readyInMinutes"":45,
   ""servings"":6,
   ""sourceUrl"":""https://www.foodista.com/recipe/XXGS8CCC/enchiladas-verdes-green-enchiladas"",
   ""image"":""https://spoonacular.com/recipeImages/642403-556x370.jpg"",
   ""imageType"":""jpg"",
   ""nutrition"":{
      ""nutrients"":[
         {
            ""name"":""Calories"",
            ""amount"":471.08,
            ""unit"":""kcal"",
            ""percentOfDailyNeeds"":23.55
         },
         {
            ""name"":""Fat"",
            ""amount"":20.34,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":31.29
         },
         {
            ""name"":""Saturated Fat"",
            ""amount"":8.34,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":52.15
         },
         {
            ""name"":""Carbohydrates"",
            ""amount"":43.28,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":14.43
         },
         {
            ""name"":""Net Carbohydrates"",
            ""amount"":35.93,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":13.06
         },
         {
            ""name"":""Sugar"",
            ""amount"":13.52,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":15.02
         },
         {
            ""name"":""Cholesterol"",
            ""amount"":91.82,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":30.61
         },
         {
            ""name"":""Sodium"",
            ""amount"":979.36,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":42.58
         },
         {
            ""name"":""Protein"",
            ""amount"":29.15,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":58.3
         },
         {
            ""name"":""Phosphorus"",
            ""amount"":544.93,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":54.49
         },
         {
            ""name"":""Selenium"",
            ""amount"":38.03,
            ""unit"":""µg"",
            ""percentOfDailyNeeds"":54.33
         },
         {
            ""name"":""Vitamin B3"",
            ""amount"":9.01,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":45.07
         },
         {
            ""name"":""Vitamin B6"",
            ""amount"":0.77,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":38.74
         },
         {
            ""name"":""Calcium"",
            ""amount"":352.95,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":35.3
         },
         {
            ""name"":""Fiber"",
            ""amount"":7.35,
            ""unit"":""g"",
            ""percentOfDailyNeeds"":29.4
         },
         {
            ""name"":""Vitamin B2"",
            ""amount"":0.48,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":28.42
         },
         {
            ""name"":""Vitamin B12"",
            ""amount"":1.34,
            ""unit"":""µg"",
            ""percentOfDailyNeeds"":22.39
         },
         {
            ""name"":""Magnesium"",
            ""amount"":83.28,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":20.82
         },
         {
            ""name"":""Vitamin C"",
            ""amount"":15.88,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":19.24
         },
         {
            ""name"":""Potassium"",
            ""amount"":657.05,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":18.77
         },
         {
            ""name"":""Vitamin B5"",
            ""amount"":1.86,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":18.58
         },
         {
            ""name"":""Zinc"",
            ""amount"":2.4,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":16.01
         },
         {
            ""name"":""Vitamin D"",
            ""amount"":2.2,
            ""unit"":""µg"",
            ""percentOfDailyNeeds"":14.68
         },
         {
            ""name"":""Vitamin B1"",
            ""amount"":0.21,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":13.93
         },
         {
            ""name"":""Manganese"",
            ""amount"":0.24,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":11.8
         },
         {
            ""name"":""Vitamin A"",
            ""amount"":530.26,
            ""unit"":""IU"",
            ""percentOfDailyNeeds"":10.61
         },
         {
            ""name"":""Copper"",
            ""amount"":0.19,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":9.71
         },
         {
            ""name"":""Vitamin E"",
            ""amount"":1.17,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":7.78
         },
         {
            ""name"":""Iron"",
            ""amount"":1.22,
            ""unit"":""mg"",
            ""percentOfDailyNeeds"":6.77
         },
         {
            ""name"":""Folate"",
            ""amount"":24.03,
            ""unit"":""µg"",
            ""percentOfDailyNeeds"":6.01
         },
         {
            ""name"":""Vitamin K"",
            ""amount"":4.08,
            ""unit"":""µg"",
            ""percentOfDailyNeeds"":3.89
         }
      ],
      ""properties"":[
         {
            ""name"":""Glycemic Index"",
            ""amount"":35.08,
            ""unit"":""""
         },
         {
            ""name"":""Glycemic Load"",
            ""amount"":14.31,
            ""unit"":""""
         },
         {
            ""name"":""Nutrition Score"",
            ""amount"":21.162608695652175,
            ""unit"":""%""
         }
      ],
      ""flavonoids"":[
         {
            ""name"":""Cyanidin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Petunidin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Delphinidin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Malvidin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Pelargonidin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Peonidin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Catechin"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Epigallocatechin"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Epicatechin"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Epicatechin 3-gallate"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Epigallocatechin 3-gallate"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Theaflavin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Thearubigins"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Eriodictyol"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Hesperetin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Naringenin"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Apigenin"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Luteolin"",
            ""amount"":0.0,
            ""unit"":""mg""
         },
         {
            ""name"":""Isorhamnetin"",
            ""amount"":0.92,
            ""unit"":""mg""
         },
         {
            ""name"":""Kaempferol"",
            ""amount"":0.12,
            ""unit"":""mg""
         },
         {
            ""name"":""Myricetin"",
            ""amount"":0.01,
            ""unit"":""mg""
         },
         {
            ""name"":""Quercetin"",
            ""amount"":3.72,
            ""unit"":""mg""
         },
         {
            ""name"":""Theaflavin-3,3'-digallate"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Theaflavin-3'-gallate"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Theaflavin-3-gallate"",
            ""amount"":0.0,
            ""unit"":""""
         },
         {
            ""name"":""Gallocatechin"",
            ""amount"":0.0,
            ""unit"":""mg""
         }
      ],
      ""ingredients"":[
         {
            ""id"":1055062,
            ""name"":""chicken breast"",
            ""amount"":0.17,
            ""unit"":""pound"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.43,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":19.66,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":87.69,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":48.38,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.15,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":158.76,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":7.88,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":55.49,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":24.19,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":22.68,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.91,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.58,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.08,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":1.08,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":3.78,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Trans Fat"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":241.66
               },
               {
                  ""name"":""Folate"",
                  ""amount"":3.02,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.14,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.28,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.05,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":16.05,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.3,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.08,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":1.96,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.44,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":86.18,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":279.72,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.15,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.57,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":10031015,
            ""name"":""anaheim chili peppers"",
            ""amount"":2.0,
            ""unit"":"""",
            ""nutrients"":[
               {
                  ""name"":""Vitamin C"",
                  ""amount"":13.44,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":3.73,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":3.7,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":372.96,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":3.77,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Calories"",
                  ""amount"":30.24,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":7.47,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":1014582,
            ""name"":""canola oil"",
            ""amount"":0.08,
            ""unit"":""cup"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":1.37,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":0.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":0.0,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":11.82,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Trans Fat"",
                  ""amount"":0.07,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":241.66
               },
               {
                  ""name"":""Folate"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":3.27,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":5.25,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":18.67,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":165.01,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":13.31,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":1230,
            ""name"":""buttermilk can be used as a substitute"",
            ""amount"":0.17,
            ""unit"":""quart"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":3.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":7.7,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":15.77,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":165.61,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":17.35,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.73,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":134.07,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.14,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":23.03,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":5.84,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":260.25,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":1.3,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.27,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.6,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":181.38,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":7.7,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":7.89,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.11,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.05,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.07,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":5.06,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.31,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":2.05,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":5.22,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.6,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":97.79,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":212.93,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.47,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.06,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":7.7,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":20081,
            ""name"":""flour"",
            ""amount"":0.33,
            ""unit"":""tablespoons"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":0.55,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":0.05,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":3.85,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":2.7,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.15,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":0.26,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":0.85,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":0.0,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":0.38,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":1.84,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":4.58,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.07,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.12,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.26,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":0.02,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":9.1,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":2.67,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.01,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":1.91,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":10611282,
            ""name"":""onion"",
            ""amount"":0.17,
            ""unit"":""medium"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.78,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":1.83,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":0.73,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":5.32,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Fluoride"",
                  ""amount"":0.2,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":1.12,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":0.09,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":0.37,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":1.36,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":4.22,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":1.4,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":3.48,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.31,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.2,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":0.02,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.03,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":7.33,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":26.77,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.07,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":1.71,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":18363,
            ""name"":""corn tortillas"",
            ""amount"":2.0,
            ""unit"":"""",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.24,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.46,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":37.44,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":23.4,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":163.28,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.78,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.17,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":6.92,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":3.17,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":1.04,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.36,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.03,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.06,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":42.12,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":19.92,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":2.6,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":3.28,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.15,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.64,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.05,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":2.96,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.74,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":1.48,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.68,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":113.36,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":96.72,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.08,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.11,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":23.19,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":1011026,
            ""name"":""cheese"",
            ""amount"":0.17,
            ""unit"":""cup"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":2.46,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.19,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":3.73,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":117.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":14.75,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.43,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":66.08,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":2.87,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":3.17,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":126.19,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":1.23,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.05,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.03,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":94.27,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.41,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":1.31,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.08,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":4.14,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.14,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.07,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":4.17,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.55,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":56.0,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":14.19,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.43,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.41,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":1228,
            ""name"":""queso fresco"",
            ""amount"":0.04,
            ""unit"":"""",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":0.31,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.03,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":0.16,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":0.01,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":0.34,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":0.24,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Trans Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":241.66
               },
               {
                  ""name"":""Folate"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":0.01,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":0.12,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":0.05,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":1056,
            ""name"":""crema"",
            ""amount"":0.08,
            ""unit"":""cup"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":1.94,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.65,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":1.92,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":5.94,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":11.31,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.04,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":14.57,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":3.68,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":0.71,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":119.41,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.17,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.88,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.03,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.06,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":19.36,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.89,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":1.15,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.07,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.47,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.15,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":3.72,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.06,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":37.95,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":23.96,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.29,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.89,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":2047,
            ""name"":""salt"",
            ""amount"":1.0,
            ""unit"":""servings"",
            ""nutrients"":[
               {
                  ""name"":""Alcohol"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Saturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":52.15
               },
               {
                  ""name"":""Sugar"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":15.02
               },
               {
                  ""name"":""Magnesium"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":193.79,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Cholesterol"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":30.61
               },
               {
                  ""name"":""Folic Acid"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B12"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":22.39
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Fluoride"",
                  ""amount"":0.01,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B3"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":45.07
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Choline"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Selenium"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":54.33
               },
               {
                  ""name"":""Vitamin A"",
                  ""amount"":0.0,
                  ""unit"":""IU"",
                  ""percentOfDailyNeeds"":10.61
               },
               {
                  ""name"":""Vitamin C"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":19.24
               },
               {
                  ""name"":""Mono Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin B2"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":28.42
               },
               {
                  ""name"":""Vitamin B5"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.58
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":0.12,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Folate"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":6.01
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Vitamin E"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":7.78
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Vitamin B1"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":13.93
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Caffeine"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Lycopene"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Poly Unsaturated Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Vitamin D"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":14.68
               },
               {
                  ""name"":""Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Calories"",
                  ""amount"":0.0,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":0.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Vitamin K"",
                  ""amount"":0.0,
                  ""unit"":""µg"",
                  ""percentOfDailyNeeds"":3.89
               },
               {
                  ""name"":""Vitamin B6"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":38.74
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         },
         {
            ""id"":14412,
            ""name"":""water"",
            ""amount"":1.0,
            ""unit"":""servings"",
            ""nutrients"":[
               {
                  ""name"":""Magnesium"",
                  ""amount"":2.37,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":20.82
               },
               {
                  ""name"":""Calcium"",
                  ""amount"":7.1,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":35.3
               },
               {
                  ""name"":""Net Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":13.06
               },
               {
                  ""name"":""Fiber"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":29.4
               },
               {
                  ""name"":""Sodium"",
                  ""amount"":11.83,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":42.58
               },
               {
                  ""name"":""Iron"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":6.77
               },
               {
                  ""name"":""Protein"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":58.3
               },
               {
                  ""name"":""Phosphorus"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":54.49
               },
               {
                  ""name"":""Fluoride"",
                  ""amount"":61.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":0.0
               },
               {
                  ""name"":""Manganese"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":11.8
               },
               {
                  ""name"":""Zinc"",
                  ""amount"":0.02,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":16.01
               },
               {
                  ""name"":""Fat"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":31.29
               },
               {
                  ""name"":""Calories"",
                  ""amount"":0.0,
                  ""unit"":""kcal"",
                  ""percentOfDailyNeeds"":23.55
               },
               {
                  ""name"":""Potassium"",
                  ""amount"":0.0,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":18.77
               },
               {
                  ""name"":""Copper"",
                  ""amount"":0.04,
                  ""unit"":""mg"",
                  ""percentOfDailyNeeds"":9.71
               },
               {
                  ""name"":""Carbohydrates"",
                  ""amount"":0.0,
                  ""unit"":""g"",
                  ""percentOfDailyNeeds"":14.43
               }
            ]
         }
      ],
      ""caloricBreakdown"":{
         ""percentProtein"":24.66,
         ""percentFat"":38.72,
         ""percentCarbs"":36.62
      },
      ""weightPerServing"":{
         ""amount"":712,
         ""unit"":""g""
      }
   },
   ""summary"":""Enchiladas Verdes (Green Enchiladas) might be just the <b>Mexican</b> recipe you are searching for. This recipe makes 6 servings with <b>471 calories</b>, <b>29g of protein</b>, and <b>20g of fat</b> each. For <b>$2.6 per serving</b>, this recipe <b>covers 22%</b> of your daily requirements of vitamins and minerals. 8 people found this recipe to be tasty and satisfying. From preparation to the plate, this recipe takes approximately <b>45 minutes</b>. A mixture of chicken breast, onion, canolan oil, and a handful of other ingredients are all it takes to make this recipe so flavorful. It is brought to you by Foodista. Only a few people really liked this main course. Overall, this recipe earns a <b>solid spoonacular score of 61%</b>. If you like this recipe, take a look at these similar recipes: <a href=\""https://spoonacular.com/recipes/enchiladas-verdes-con-pavo-green-chile-turkey-enchiladas-555668\"">Enchiladas Verdes con Pavo (Green Chile Turkey Enchiladas)</a>, <a href=\""https://spoonacular.com/recipes/enchiladas-verdes-green-enchiladas-1282881\"">Enchiladas Verdes (Green Enchiladas)</a>, and <a href=\""https://spoonacular.com/recipes/enchiladas-verdes-green-enchiladas-1772459\"">Enchiladas Verdes (Green Enchiladas)</a>."",
   ""cuisines"":[
      ""Mexican""
   ],
   ""dishTypes"":[
      ""lunch"",
      ""main course"",
      ""main dish"",
      ""dinner""
   ],
   ""diets"":[
      
   ],
   ""occasions"":[
      
   ],
   ""winePairing"":{
      ""pairedWines"":[
         ""pinot noir"",
         ""riesling"",
         ""sparkling rose""
      ],
      ""pairingText"":""Enchilada works really well with Pinot Noir, Riesling, and Sparkling rosé. Acidic white wines like riesling or low-tannin reds like pinot noir can work well with Mexican dishes. Sparkling rosé is a safe pairing too. You could try MacMurray Ranch Russian River Pinot Noir. Reviewers quite like it with a 4.3 out of 5 star rating and a price of about 24 dollars per bottle."",
      ""productMatches"":[
         {
            ""id"":433325,
            ""title"":""MacMurray Ranch Russian River Pinot Noir"",
            ""description"":""Our MacMurray Ranch 2012 Russian River Valley Pinot Noir opens with aromas of lavender and boysenberry that give way to flavors of dark cherry and pomegranate. This luscious wine has a silky mouthfeel, framed by subtle hints of oak from barrel aging."",
            ""price"":""$23.99"",
            ""imageUrl"":""https://spoonacular.com/productImages/433325-312x231.jpg"",
            ""averageRating"":0.86,
            ""ratingCount"":52.0,
            ""score"":0.8536305732484076,
            ""link"":""https://click.linksynergy.com/deeplink?id=*QCiIS6t4gA&mid=2025&murl=https%3A%2F%2Fwww.wine.com%2Fproduct%2Fmacmurray-ranch-russian-river-pinot-noir-2012%2F128761""
         }
      ]
   },
   ""instructions"":""Roast Chili Peppers\nPreheat broiler. Select firm, meaty peppers without wrinkles for roasting. Wash thoroughly. Place peppers evenly in a single layer on a foil-lined cookie sheet. Place under broiler. Watch them closely as the skin will blister and turn black within minutes. Turn the peppers after 5 minutes to blister all sides evenly. When done, the pepper skins should be evenly blistered and mostly black. Place roasted peppers in a plastic bag, cover with a kitchen towel and when cool, rub off blackened skin. Tear open and pull out the seed pod and stem.\nSauce\nIn a blender combine the peppers, flour, and half of the suero or buttermilk and blend until creamy. Pour mixture into medium skillet and set over medium-low heat to warm. Add additional suero or buttermilk and stir. Taste and season with salt, usually about 2 teaspoons. If the sauce is too spicy, add  cup of crema or sour cream and stir. If the sauce is too thick, add water until desired consistency is reached.\nChicken (Optional)\nIn a pot with enough water to cover, boil chicken breasts 25 minutes or until juices run clear. Drain, cool, and shred. Optional time-saver: shred a store bought rotisserie chicken.\nStacked Style\nFry tortillas in hot oil until softened. Drain on paper towels. Soften tortillas by soaking in sauce one at a time. Place softened tortillas on individual serving plates. Layer with cooked chicken, cheese, and onion. Repeat process for a total of 3 tortillas for each serving.\nOven Style\nPreheat oven to 350 degrees. Spread 1 cup of the sauce in an ungreased 9-by-13-inch baking dish. Fry tortillas in hot oil just until softened. Drain on paper towels. Fill with cooked chicken, cheese, and onion. Roll, placing seam side down.\nPour 2 cups of the sauce over enchiladas. Sprinkle with crumbled queso fresco and bake until warm, about 15 minutes. Serve with a dollop of crema or sour cream and your favorite side dish."",
   ""analyzedInstructions"":[
      {
         ""name"":"""",
         ""steps"":[
            {
               ""number"":1,
               ""step"":""Roast Chili Peppers"",
               ""ingredients"":[
                  {
                     ""id"":11962,
                     ""name"":""arbol chile"",
                     ""localizedName"":""arbol chile"",
                     ""image"":""dried-arbol-chiles.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":2,
               ""step"":""Preheat broiler. Select firm, meaty peppers without wrinkles for roasting. Wash thoroughly."",
               ""ingredients"":[
                  {
                     ""id"":10111333,
                     ""name"":""peppers"",
                     ""localizedName"":""peppers"",
                     ""image"":""green-pepper.jpg""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":405914,
                     ""name"":""broiler"",
                     ""localizedName"":""broiler"",
                     ""image"":""oven.jpg""
                  }
               ]
            },
            {
               ""number"":3,
               ""step"":""Place peppers evenly in a single layer on a foil-lined cookie sheet."",
               ""ingredients"":[
                  {
                     ""id"":10111333,
                     ""name"":""peppers"",
                     ""localizedName"":""peppers"",
                     ""image"":""green-pepper.jpg""
                  },
                  {
                     ""id"":10118192,
                     ""name"":""cookies"",
                     ""localizedName"":""cookies"",
                     ""image"":""shortbread-cookies.jpg""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":404727,
                     ""name"":""baking sheet"",
                     ""localizedName"":""baking sheet"",
                     ""image"":""baking-sheet.jpg""
                  },
                  {
                     ""id"":404765,
                     ""name"":""aluminum foil"",
                     ""localizedName"":""aluminum foil"",
                     ""image"":""aluminum-foil.png""
                  }
               ]
            },
            {
               ""number"":4,
               ""step"":""Place under broiler. Watch them closely as the skin will blister and turn black within minutes. Turn the peppers after 5 minutes to blister all sides evenly. When done, the pepper skins should be evenly blistered and mostly black."",
               ""ingredients"":[
                  {
                     ""id"":10111333,
                     ""name"":""peppers"",
                     ""localizedName"":""peppers"",
                     ""image"":""green-pepper.jpg""
                  },
                  {
                     ""id"":1002030,
                     ""name"":""pepper"",
                     ""localizedName"":""pepper"",
                     ""image"":""pepper.jpg""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":405914,
                     ""name"":""broiler"",
                     ""localizedName"":""broiler"",
                     ""image"":""oven.jpg""
                  }
               ],
               ""length"":{
                  ""number"":5,
                  ""unit"":""minutes""
               }
            },
            {
               ""number"":5,
               ""step"":""Place roasted peppers in a plastic bag, cover with a kitchen towel and when cool, rub off blackened skin. Tear open and pull out the seed pod and stem."",
               ""ingredients"":[
                  {
                     ""id"":10111333,
                     ""name"":""peppers"",
                     ""localizedName"":""peppers"",
                     ""image"":""green-pepper.jpg""
                  },
                  {
                     ""id"":1012034,
                     ""name"":""dry seasoning rub"",
                     ""localizedName"":""dry seasoning rub"",
                     ""image"":""seasoning.png""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":221439,
                     ""name"":""kitchen towels"",
                     ""localizedName"":""kitchen towels"",
                     ""image"":""dish-towel.jpg""
                  },
                  {
                     ""id"":221671,
                     ""name"":""ziploc bags"",
                     ""localizedName"":""ziploc bags"",
                     ""image"":""plastic-bag.jpg""
                  }
               ]
            },
            {
               ""number"":6,
               ""step"":""Sauce"",
               ""ingredients"":[
                  {
                     ""id"":0,
                     ""name"":""sauce"",
                     ""localizedName"":""sauce"",
                     ""image"":""""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":7,
               ""step"":""In a blender combine the peppers, flour, and half of the suero or buttermilk and blend until creamy."",
               ""ingredients"":[
                  {
                     ""id"":1230,
                     ""name"":""buttermilk"",
                     ""localizedName"":""buttermilk"",
                     ""image"":""buttermilk.jpg""
                  },
                  {
                     ""id"":10111333,
                     ""name"":""peppers"",
                     ""localizedName"":""peppers"",
                     ""image"":""green-pepper.jpg""
                  },
                  {
                     ""id"":20081,
                     ""name"":""all purpose flour"",
                     ""localizedName"":""all purpose flour"",
                     ""image"":""flour.png""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":404726,
                     ""name"":""blender"",
                     ""localizedName"":""blender"",
                     ""image"":""blender.png""
                  }
               ]
            },
            {
               ""number"":8,
               ""step"":""Pour mixture into medium skillet and set over medium-low heat to warm."",
               ""ingredients"":[
                  
               ],
               ""equipment"":[
                  {
                     ""id"":404645,
                     ""name"":""frying pan"",
                     ""localizedName"":""frying pan"",
                     ""image"":""pan.png""
                  }
               ]
            },
            {
               ""number"":9,
               ""step"":""Add additional suero or buttermilk and stir. Taste and season with salt, usually about 2 teaspoons. If the sauce is too spicy, add  cup of crema or sour cream and stir. If the sauce is too thick, add water until desired consistency is reached."",
               ""ingredients"":[
                  {
                     ""id"":1230,
                     ""name"":""buttermilk"",
                     ""localizedName"":""buttermilk"",
                     ""image"":""buttermilk.jpg""
                  },
                  {
                     ""id"":1056,
                     ""name"":""sour cream"",
                     ""localizedName"":""sour cream"",
                     ""image"":""sour-cream.jpg""
                  },
                  {
                     ""id"":93772,
                     ""name"":""mexican crema"",
                     ""localizedName"":""mexican crema"",
                     ""image"":""plain-yogurt.jpg""
                  },
                  {
                     ""id"":0,
                     ""name"":""sauce"",
                     ""localizedName"":""sauce"",
                     ""image"":""""
                  },
                  {
                     ""id"":14412,
                     ""name"":""water"",
                     ""localizedName"":""water"",
                     ""image"":""water.png""
                  },
                  {
                     ""id"":2047,
                     ""name"":""salt"",
                     ""localizedName"":""salt"",
                     ""image"":""salt.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":10,
               ""step"":""Chicken (Optional)"",
               ""ingredients"":[
                  {
                     ""id"":5006,
                     ""name"":""whole chicken"",
                     ""localizedName"":""whole chicken"",
                     ""image"":""whole-chicken.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":11,
               ""step"":""In a pot with enough water to cover, boil chicken breasts 25 minutes or until juices run clear."",
               ""ingredients"":[
                  {
                     ""id"":5062,
                     ""name"":""chicken breast"",
                     ""localizedName"":""chicken breast"",
                     ""image"":""chicken-breasts.png""
                  },
                  {
                     ""id"":14412,
                     ""name"":""water"",
                     ""localizedName"":""water"",
                     ""image"":""water.png""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":404752,
                     ""name"":""pot"",
                     ""localizedName"":""pot"",
                     ""image"":""stock-pot.jpg""
                  }
               ],
               ""length"":{
                  ""number"":25,
                  ""unit"":""minutes""
               }
            },
            {
               ""number"":12,
               ""step"":""Drain, cool, and shred. Optional time-saver: shred a store bought rotisserie chicken."",
               ""ingredients"":[
                  {
                     ""id"":99246,
                     ""name"":""rotisserie chicken"",
                     ""localizedName"":""rotisserie chicken"",
                     ""image"":""rotisserie-chicken.png""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":13,
               ""step"":""Stacked Style"",
               ""ingredients"":[
                  
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":14,
               ""step"":""Fry tortillas in hot oil until softened."",
               ""ingredients"":[
                  {
                     ""id"":18364,
                     ""name"":""tortilla"",
                     ""localizedName"":""tortilla"",
                     ""image"":""flour-tortilla.jpg""
                  },
                  {
                     ""id"":4582,
                     ""name"":""cooking oil"",
                     ""localizedName"":""cooking oil"",
                     ""image"":""vegetable-oil.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":15,
               ""step"":""Drain on paper towels. Soften tortillas by soaking in sauce one at a time."",
               ""ingredients"":[
                  {
                     ""id"":18364,
                     ""name"":""tortilla"",
                     ""localizedName"":""tortilla"",
                     ""image"":""flour-tortilla.jpg""
                  },
                  {
                     ""id"":0,
                     ""name"":""sauce"",
                     ""localizedName"":""sauce"",
                     ""image"":""""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":405895,
                     ""name"":""paper towels"",
                     ""localizedName"":""paper towels"",
                     ""image"":""paper-towels.jpg""
                  }
               ]
            },
            {
               ""number"":16,
               ""step"":""Place softened tortillas on individual serving plates."",
               ""ingredients"":[
                  {
                     ""id"":18364,
                     ""name"":""tortilla"",
                     ""localizedName"":""tortilla"",
                     ""image"":""flour-tortilla.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":17,
               ""step"":""Layer with cooked chicken, cheese, and onion. Repeat process for a total of 3 tortillas for each serving."",
               ""ingredients"":[
                  {
                     ""id"":5114,
                     ""name"":""cooked chicken"",
                     ""localizedName"":""cooked chicken"",
                     ""image"":""rotisserie-chicken.png""
                  },
                  {
                     ""id"":18364,
                     ""name"":""tortilla"",
                     ""localizedName"":""tortilla"",
                     ""image"":""flour-tortilla.jpg""
                  },
                  {
                     ""id"":1041009,
                     ""name"":""cheese"",
                     ""localizedName"":""cheese"",
                     ""image"":""cheddar-cheese.png""
                  },
                  {
                     ""id"":11282,
                     ""name"":""onion"",
                     ""localizedName"":""onion"",
                     ""image"":""brown-onion.png""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":18,
               ""step"":""Oven Style"",
               ""ingredients"":[
                  
               ],
               ""equipment"":[
                  {
                     ""id"":404784,
                     ""name"":""oven"",
                     ""localizedName"":""oven"",
                     ""image"":""oven.jpg""
                  }
               ]
            },
            {
               ""number"":19,
               ""step"":""Preheat oven to 350 degrees."",
               ""ingredients"":[
                  
               ],
               ""equipment"":[
                  {
                     ""id"":404784,
                     ""name"":""oven"",
                     ""localizedName"":""oven"",
                     ""image"":""oven.jpg""
                  }
               ]
            },
            {
               ""number"":20,
               ""step"":""Spread 1 cup of the sauce in an ungreased 9-by-13-inch baking dish. Fry tortillas in hot oil just until softened."",
               ""ingredients"":[
                  {
                     ""id"":18364,
                     ""name"":""tortilla"",
                     ""localizedName"":""tortilla"",
                     ""image"":""flour-tortilla.jpg""
                  },
                  {
                     ""id"":0,
                     ""name"":""spread"",
                     ""localizedName"":""spread"",
                     ""image"":""""
                  },
                  {
                     ""id"":0,
                     ""name"":""sauce"",
                     ""localizedName"":""sauce"",
                     ""image"":""""
                  },
                  {
                     ""id"":4582,
                     ""name"":""cooking oil"",
                     ""localizedName"":""cooking oil"",
                     ""image"":""vegetable-oil.jpg""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":404646,
                     ""name"":""baking pan"",
                     ""localizedName"":""baking pan"",
                     ""image"":""roasting-pan.jpg""
                  }
               ]
            },
            {
               ""number"":21,
               ""step"":""Drain on paper towels. Fill with cooked chicken, cheese, and onion."",
               ""ingredients"":[
                  {
                     ""id"":5114,
                     ""name"":""cooked chicken"",
                     ""localizedName"":""cooked chicken"",
                     ""image"":""rotisserie-chicken.png""
                  },
                  {
                     ""id"":1041009,
                     ""name"":""cheese"",
                     ""localizedName"":""cheese"",
                     ""image"":""cheddar-cheese.png""
                  },
                  {
                     ""id"":11282,
                     ""name"":""onion"",
                     ""localizedName"":""onion"",
                     ""image"":""brown-onion.png""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":405895,
                     ""name"":""paper towels"",
                     ""localizedName"":""paper towels"",
                     ""image"":""paper-towels.jpg""
                  }
               ]
            },
            {
               ""number"":22,
               ""step"":""Roll, placing seam side down."",
               ""ingredients"":[
                  {
                     ""id"":0,
                     ""name"":""roll"",
                     ""localizedName"":""roll"",
                     ""image"":""dinner-yeast-rolls.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":23,
               ""step"":""Pour 2 cups of the sauce over enchiladas."",
               ""ingredients"":[
                  {
                     ""id"":0,
                     ""name"":""sauce"",
                     ""localizedName"":""sauce"",
                     ""image"":""""
                  }
               ],
               ""equipment"":[
                  
               ]
            },
            {
               ""number"":24,
               ""step"":""Sprinkle with crumbled queso fresco and bake until warm, about 15 minutes."",
               ""ingredients"":[
                  {
                     ""id"":1228,
                     ""name"":""queso fresco"",
                     ""localizedName"":""queso fresco"",
                     ""image"":""camembert.png""
                  }
               ],
               ""equipment"":[
                  {
                     ""id"":404784,
                     ""name"":""oven"",
                     ""localizedName"":""oven"",
                     ""image"":""oven.jpg""
                  }
               ],
               ""length"":{
                  ""number"":15,
                  ""unit"":""minutes""
               }
            },
            {
               ""number"":25,
               ""step"":""Serve with a dollop of crema or sour cream and your favorite side dish."",
               ""ingredients"":[
                  {
                     ""id"":1056,
                     ""name"":""sour cream"",
                     ""localizedName"":""sour cream"",
                     ""image"":""sour-cream.jpg""
                  },
                  {
                     ""id"":93772,
                     ""name"":""mexican crema"",
                     ""localizedName"":""mexican crema"",
                     ""image"":""plain-yogurt.jpg""
                  }
               ],
               ""equipment"":[
                  
               ]
            }
         ]
      }
   ],
   ""originalId"":null,
   ""spoonacularSourceUrl"":""https://spoonacular.com/enchiladas-verdes-green-enchiladas-642403""
}
";

        public static string IngredientResponse = @"
{
    ""id"": 1055062,
    ""original"": ""boneless skinless chicken breasts"",
    ""originalName"": ""boneless skinless chicken breasts"",
    ""name"": ""boneless skinless chicken breasts"",
    ""amount"": 100.0,
    ""unit"": ""gram"",
    ""unitShort"": ""g"",
    ""unitLong"": ""grams"",
    ""possibleUnits"": [
        ""unit"",
        ""piece"",
        ""g"",
        ""oz"",
        ""breast"",
        ""cup"",
        ""serving""
    ],
    ""estimatedCost"": {
        ""value"": 88.67,
        ""unit"": ""US Cents""
    },
    ""consistency"": ""solid"",
    ""shoppingListUnits"": [
        ""ounces"",
        ""pounds""
    ],
    ""aisle"": ""Meat"",
    ""image"": ""chicken-breasts.png"",
    ""meta"": [],
    ""nutrition"": {
        ""nutrients"": [
            {
                ""name"": ""Alcohol"",
                ""amount"": 0.0,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Saturated Fat"",
                ""amount"": 0.57,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 3.54
            },
            {
                ""name"": ""Sugar"",
                ""amount"": 0.0,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Magnesium"",
                ""amount"": 26.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 6.5
            },
            {
                ""name"": ""Sodium"",
                ""amount"": 116.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 5.04
            },
            {
                ""name"": ""Cholesterol"",
                ""amount"": 64.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 21.33
            },
            {
                ""name"": ""Folic Acid"",
                ""amount"": 0.0,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Vitamin B12"",
                ""amount"": 0.2,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 3.33
            },
            {
                ""name"": ""Phosphorus"",
                ""amount"": 210.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 21.0
            },
            {
                ""name"": ""Vitamin B3"",
                ""amount"": 10.43,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 52.15
            },
            {
                ""name"": ""Manganese"",
                ""amount"": 0.01,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 0.75
            },
            {
                ""name"": ""Choline"",
                ""amount"": 73.4,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Selenium"",
                ""amount"": 32.0,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 45.71
            },
            {
                ""name"": ""Vitamin A"",
                ""amount"": 30.0,
                ""unit"": ""IU"",
                ""percentOfDailyNeeds"": 0.6
            },
            {
                ""name"": ""Vitamin C"",
                ""amount"": 1.2,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 1.45
            },
            {
                ""name"": ""Net Carbohydrates"",
                ""amount"": 0.0,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Mono Unsaturated Fat"",
                ""amount"": 0.76,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Vitamin B2"",
                ""amount"": 0.1,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 5.88
            },
            {
                ""name"": ""Vitamin B5"",
                ""amount"": 1.42,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 14.25
            },
            {
                ""name"": ""Calcium"",
                ""amount"": 5.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 0.5
            },
            {
                ""name"": ""Trans Fat"",
                ""amount"": 0.01,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 120.0
            },
            {
                ""name"": ""Folate"",
                ""amount"": 4.0,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 1.0
            },
            {
                ""name"": ""Fiber"",
                ""amount"": 0.0,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Vitamin E"",
                ""amount"": 0.19,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 1.27
            },
            {
                ""name"": ""Iron"",
                ""amount"": 0.37,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 2.06
            },
            {
                ""name"": ""Vitamin B1"",
                ""amount"": 0.06,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 4.27
            },
            {
                ""name"": ""Protein"",
                ""amount"": 21.23,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 42.46
            },
            {
                ""name"": ""Caffeine"",
                ""amount"": 0.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Lycopene"",
                ""amount"": 0.0,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Poly Unsaturated Fat"",
                ""amount"": 0.4,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            },
            {
                ""name"": ""Vitamin D"",
                ""amount"": 0.1,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 0.67
            },
            {
                ""name"": ""Fat"",
                ""amount"": 2.59,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 3.98
            },
            {
                ""name"": ""Zinc"",
                ""amount"": 0.58,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 3.87
            },
            {
                ""name"": ""Calories"",
                ""amount"": 114.0,
                ""unit"": ""kcal"",
                ""percentOfDailyNeeds"": 5.7
            },
            {
                ""name"": ""Potassium"",
                ""amount"": 370.0,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 10.57
            },
            {
                ""name"": ""Copper"",
                ""amount"": 0.03,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 1.35
            },
            {
                ""name"": ""Vitamin K"",
                ""amount"": 0.2,
                ""unit"": ""µg"",
                ""percentOfDailyNeeds"": 0.19
            },
            {
                ""name"": ""Vitamin B6"",
                ""amount"": 0.75,
                ""unit"": ""mg"",
                ""percentOfDailyNeeds"": 37.45
            },
            {
                ""name"": ""Carbohydrates"",
                ""amount"": 0.0,
                ""unit"": ""g"",
                ""percentOfDailyNeeds"": 0.0
            }
        ],
        ""properties"": [
            {
                ""name"": ""Glycemic Index"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Glycemic Load"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Nutrition Score"",
                ""amount"": 9.340000000000002,
                ""unit"": ""%""
            }
        ],
        ""flavonoids"": [
            {
                ""name"": ""Cyanidin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Petunidin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Delphinidin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Malvidin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Pelargonidin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Peonidin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Catechin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Epigallocatechin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Epicatechin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Epicatechin 3-gallate"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Epigallocatechin 3-gallate"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Theaflavin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Thearubigins"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Eriodictyol"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Hesperetin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Naringenin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Apigenin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Luteolin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Isorhamnetin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Kaempferol"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Myricetin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Quercetin"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Theaflavin-3,3'-digallate"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Theaflavin-3'-gallate"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Theaflavin-3-gallate"",
                ""amount"": 0.0,
                ""unit"": """"
            },
            {
                ""name"": ""Gallocatechin"",
                ""amount"": 0.0,
                ""unit"": """"
            }
        ],
        ""caloricBreakdown"": {
            ""percentProtein"": 78.46,
            ""percentFat"": 21.54,
            ""percentCarbs"": 0.0
        },
        ""weightPerServing"": {
            ""amount"": 100,
            ""unit"": ""g""
        }
    },
    ""categoryPath"": [
        ""chicken breast"",
        ""chicken"",
        ""poultry"",
        ""meat""
    ]
}
";

        public static string ConvertUnitResponse = @"
{
    ""sourceAmount"": 12.0,
    ""sourceUnit"": ""liter"",
    ""targetAmount"": 12375.94,
    ""targetUnit"": ""grams"",
    ""answer"": ""12 liter milk are 12375.94 grams."",
    ""type"": ""CONVERSION""
}
";
    }
}
