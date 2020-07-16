using BrewjournalApp.Services;
using BrewjournalApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrewjournalApp.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        private readonly RecipesService client;
        public string SearchTerm { get; set; }

        public RecipeDto SelectedRecipe { get; set; } = new RecipeDto();

        public string SelectedRecipeName => SelectedRecipe != null ? SelectedRecipe.Name : "";

        public ICollection<RecipeDto> Recipes { get; set; } = new ObservableCollection<RecipeDto>();

        public ICommand SearchRecipeCommand { get; set; }
        public ICommand OpenRecipeDetailsCommand { get; set; }

        public RecipesViewModel()
        {
            client = new RecipesService();
            SearchRecipeCommand = new Command(async () => await SearchRecipes());
            OpenRecipeDetailsCommand = new Command(async () => await ShowRecipeDetails());
        }

        public async Task SearchRecipes()
        {
            Recipes.Clear();
            Recipes = await client.SearchAsync(SearchTerm);
        }

        public async Task ShowRecipeDetails()
        {
            if (SelectedRecipe != null && SelectedRecipe.Id > 0)
            {
                try
                {
                    await Navigation.PushAsync(new RecipeDetailsPage(SelectedRecipe.Id));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
