using brewjournal.Domain.Entities;
using brewjournal.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace brewjournal.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if(!context.IngredientCategories.Any())
            {
                AddCategories(context);
            }

            if(!context.Ingredients.Any())
            {
                AddIngredients(context);
            }

            if(!context.Recipes.Any())
            {
                AddRecipes(context);
            }
        }

        public static void AddCategories (ApplicationDbContext context)
        {
            try
            {
                context.IngredientCategories.Add(new IngredientCategory
                {
                    Name = "Hops"
                });

                context.IngredientCategories.Add(new IngredientCategory
                {
                    Name = "Grain"
                });

                context.IngredientCategories.Add(new IngredientCategory
                {
                    Name = "Yeast"
                });

                context.IngredientCategories.Add(new IngredientCategory
                {
                    Name = "Extract"
                });

                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Failed to seed database");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public static void AddIngredients(ApplicationDbContext context)
        {
            IngredientCategory hops = context.IngredientCategories.Where(c => c.Name == "Hops").First();
            IngredientCategory yeast = context.IngredientCategories.Where(c => c.Name == "Yeast").First();
            IngredientCategory grain = context.IngredientCategories.Where(c => c.Name == "Grain").First();
            IngredientCategory extract = context.IngredientCategories.Where(c => c.Name == "Extract").First();

            context.Ingredients.Add(new Ingredient
            {
                Category = hops,
                Name = "Ämarillo"
            });

            context.Ingredients.Add(new Ingredient
            {
                Category = hops,
                Name = "Galaxy"
            });

            context.Ingredients.Add(new Ingredient
            {
                Category = yeast,
                Name = "Safale US-05"
            });

            context.Ingredients.Add(new Ingredient
            {
                Category = grain,
                Name = "Crystal"
            });

            context.Ingredients.Add(new Ingredient
            {
                Category = grain,
                Name = "Vienna"
            });

            context.Ingredients.Add(new Ingredient
            {
                Category = extract,
                Name = "Morgan's Pacific Ale"
            });

            context.Ingredients.Add(new Ingredient
            {
                Category = extract,
                Name = "Coopers Pale Ale"
            });

            context.SaveChanges();
        }

        public static void AddRecipes(ApplicationDbContext context)
        {
            var recipe = new Recipe
            {
                LiquidUnits = 0,
                MassUnits = 0,
                TemperatureUnit = 0,
                Name = "Clone & Wood",
                Style = "Pacific Ale",
                Notes = "Replica of Stone and Wood Pacific Ale"
            };

            context.Recipes.Add(recipe);

            var hop = context.Ingredients.Where(i => i.Name == "Galaxy").First();
            var extract = context.Ingredients.Where(i => i.Name == "Morgan's Pacific Ale").First();
            var yeast = context.Ingredients.Where(i => i.Name == "Safale US-05").First();

            context.RecipeIngredients.Add(new RecipeIngredients
            {
                Recipe = recipe,
                Ingredient = hop,
                Quantity = 1
            });

            context.RecipeIngredients.Add(new RecipeIngredients
            {
                Recipe = recipe,
                Ingredient = yeast,
                Quantity = 1
            });

            context.RecipeIngredients.Add(new RecipeIngredients
            {
                Recipe = recipe,
                Ingredient = extract,
                Quantity = 1
            });

            context.SaveChanges();
        }
    }
}
