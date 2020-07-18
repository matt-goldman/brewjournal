using BrewjournalApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace BrewjournalApp.ViewModels
{
    public class RecipeDetailsViewModel : BaseViewModel
    {
        private RecipeDto _recipe;

        public string Name { get; set; }
        public string Style { get; set; }
        public ObservableCollection<RecipeIngredientDto> Ingredients { get; set; } = new ObservableCollection<RecipeIngredientDto>();
        public string MassUnit { get; set; }
        public string LiquidUnit { get; set; }
        public string TempUnit { get; set; }
        public string Notes { get; set; }

        private readonly RecipesService _service;

        public RecipeDetailsViewModel(int recipeId)
        {
            _service = new RecipesService();
            _ = Init(recipeId);
        }

        private async Task Init(int id)
        {
            _recipe = await _service.GetAsync(id);
            Name = _recipe.Name;
            Style = _recipe.Style;
            MassUnit = _recipe.MassUnits.ToString();
            LiquidUnit = _recipe.LiquidUnits.ToString();
            TempUnit = _recipe.TemperatureUnits.ToString();
            Notes = _recipe.Notes.ToString();
            _recipe.Ingredients.ForEach(i => Ingredients.Add(i));
        }
    }
}
