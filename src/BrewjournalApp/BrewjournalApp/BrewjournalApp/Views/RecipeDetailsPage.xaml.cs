using BrewjournalApp.Services;
using BrewjournalApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrewjournalApp.Views
{
    //[QueryProperty(nameof(RecipeId), "id")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class RecipeDetailsPage : ContentPage
    {
        public RecipeDetailsViewModel viewModel { get; set; }

        //public string RecipeId
        //{
        //    set => recipeId = int.Parse(Uri.UnescapeDataString(value));
        //}

        //private int recipeId;

        public RecipeDetailsPage()
        {
            InitializeComponent();
            viewModel = new RecipeDetailsViewModel(1);
            BindingContext = viewModel;
        }
    }
}