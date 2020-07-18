using BrewjournalApp.Services;
using BrewjournalApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrewjournalApp.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        private readonly RecipesService _service;

        public string SearchTerm { get; set; }

        public RecipeDto SelectedRecipe { get; set; } = new RecipeDto();

        public ICollection<RecipeDto> Recipes { get; set; } = new ObservableCollection<RecipeDto>();

        public ICommand SearchRecipeCommand { get; set; }
        public ICommand OpenRecipeDetailsCommand { get; set; }
        public ICommand AddNewRecipeCommand { get; set; }

        public RecipesViewModel()
        {
            _service = new RecipesService();
            SearchRecipeCommand = new Command(async () => await SearchRecipes());
            OpenRecipeDetailsCommand = new Command(async () => await ShowRecipeDetails());
            AddNewRecipeCommand = new Command(async () => await Navigation.PushAsync(new NewRecipePage()));
            MessagingCenter.Subscribe<object, int>(this, "RecipeAdded", async (obj, id) => await Navigation.PushAsync(new RecipeDetailsPage(id)));
        }

        public async Task SearchRecipes()
        {
            Recipes.Clear();
            Recipes = await _service.SearchAsync(SearchTerm);
        }

        public async Task ShowRecipeDetails()
        {
            if (SelectedRecipe != null && SelectedRecipe.Id > 0)
            {
                await Navigation.PushAsync(new RecipeDetailsPage(SelectedRecipe.Id));
            }
        }
    }
}
