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
    public partial class RecipesPage : ContentPage
    {
        public RecipesViewModel viewModel { get; set; }
        public RecipesPage()
        {
            InitializeComponent();
            viewModel = new RecipesViewModel();
            BindingContext = viewModel;
        }
    }
}