using BrewjournalApp.Services;
using BrewjournalApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrewjournalApp.ViewModels
{
    public class NewRecipeViewModel : BaseViewModel
    {
        public RecipeDto Recipe { get; set; } = new RecipeDto();
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private RecipesService service { get; set; }

        public NewRecipeViewModel()
        {
            service = new RecipesService();
            SaveCommand = new Command(async () => await SaveRecipe());
            CancelCommand = new Command(async () => await Navigation.PopAsync());
        }

        public async Task SaveRecipe()
        {
            int id = await service.CreateAsync(Recipe);
            MessagingCenter.Send<object, int>(this, "RecipeAdded", id);
        }
    }
}
