using BrewjournalApp.Views;

using Xamarin.Forms;

namespace BrewjournalApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("recipedetails", typeof(RecipeDetailsPage));
        }
    }
}
