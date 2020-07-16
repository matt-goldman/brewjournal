using BrewjournalApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BrewjournalApp.ViewModels
{
    public class RecipeDetailsViewModel
    {
        private RecipeDto _recipe;

        public string Name => _recipe.Name;
        public string Style => _recipe.Style;
        public ObservableCollection<RecipeIngredientDto> Ingredients { get; set; } = new ObservableCollection<RecipeIngredientDto>();
        public string MassUnit => _recipe.MassUnits.ToString();
        public string LiquidUnit => _recipe.LiquidUnits.ToString();
        public string TempUnit => _recipe.TemperatureUnits.ToString();
        public string Notes => _recipe.Notes;

        private readonly RecipesService _service;

        public RecipeDetailsViewModel(int recipeId)
        {
            _service = new RecipesService();
            _ = Init(recipeId);
        }

        private async Task Init(int id)
        {
            _recipe = await _service.GetAsync(id);
            _recipe.Ingredients.ForEach(i => Ingredients.Add(i));
        }
    }
}
