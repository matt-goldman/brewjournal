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
    public partial class NewRecipePage : ContentPage
    {
        public NewRecipeViewModel viewModel { get; set; }
        public NewRecipePage()
        {
            InitializeComponent();
            viewModel = new NewRecipeViewModel();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}