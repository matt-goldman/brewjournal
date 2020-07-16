using BrewjournalApp.ViewModels;
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