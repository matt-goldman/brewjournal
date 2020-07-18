using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace BrewjournalApp.Services
{
    public class RecipesService : BaseService
    {
        private readonly RecipesClient _service;

        public RecipesService()
        {
            _service = new RecipesClient(apiUri, httpClient);
        }

        public async Task<RecipeDto> GetAsync(int id)
        {
            return await _service.GetAsync(id);
        }

        public async Task<ICollection<RecipeDto>> SearchAsync(string searchterm)
        {
            ICollection<RecipeDto> recipes = new ObservableCollection<RecipeDto>();

            SearchRecipeQuery query = new SearchRecipeQuery();
            query.Name = searchterm;
            var vm = await _service.SearchAsync(query);

            vm.Recipes.ForEach(r =>
            {
                recipes.Add(r);
            });

            return recipes;
        }

        public async Task<int> CreateAsync(RecipeDto recipe)
        {
            return await _service.CreateAsync(recipe);
        }

    }
}
