using BrewjournalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrewjournalApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailsPage : ContentPage
    {
        RecipeDetailsViewModel viewModel { get; set; }

        public RecipeDetailsPage(int RecipeId)
        {
            InitializeComponent();
            viewModel = new RecipeDetailsViewModel(RecipeId);
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}