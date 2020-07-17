using BrewjournalApp.Services;
using BrewjournalApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrewjournalApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class RecipeDetailsPage : ContentPage
    {
        public RecipeDetailsViewModel viewModel { get; set; }

        public RecipeDetailsPage(int RecipeId)
        {
            InitializeComponent();
            viewModel = new RecipeDetailsViewModel(RecipeId);
            BindingContext = viewModel;
        }
    }
}