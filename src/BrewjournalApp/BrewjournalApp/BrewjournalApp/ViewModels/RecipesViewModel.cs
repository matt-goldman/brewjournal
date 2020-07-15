using BrewjournalApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrewjournalApp.ViewModels
{
    public class RecipesViewModel
    {
        private readonly RecipesService client;
        public string SearchTerm { get; set; }

        private CancellationTokenSource _throttleCts = new CancellationTokenSource();

        public ICollection<RecipeDto> Recipes { get; set; } = new ObservableCollection<RecipeDto>();

        public ICommand SearchRecipeCommand { get; set; }

        public RecipesViewModel()
        {
            client = new RecipesService();
            SearchRecipeCommand = new Command(async () => await SearchRecipes());//DebouncedSearch().ConfigureAwait(false));
        }

        public async Task SearchRecipes()
        {
            Recipes.Clear();
            Recipes = await client.SearchAsync(SearchTerm);
        }

        private async Task DebouncedSearch()
        {
            Interlocked.Exchange(ref _throttleCts, new CancellationTokenSource()).Cancel();

            await Task.Delay(TimeSpan.FromMilliseconds(500), _throttleCts.Token)
                .ContinueWith(async task => await SearchRecipes(),
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
