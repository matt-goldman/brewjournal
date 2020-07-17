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
    public partial class BatchesPage : ContentPage
    {
        public BatchesViewModel viewModel { get; set; }

        public BatchesPage()
        {
            InitializeComponent();
            viewModel = new BatchesViewModel();
            BindingContext = viewModel;
        }
    }
}