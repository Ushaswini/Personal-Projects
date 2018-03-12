using Places.Models;
using Places.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Places.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceDetailsPage : ContentPage
    {

        PlaceDetailsViewModel viewModel;
        public PlaceDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PlaceDetailsViewModel("");
        }

        public PlaceDetailsPage(string id)
        {
            InitializeComponent();
            BindingContext = viewModel = new PlaceDetailsViewModel(id);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDetailsCommand.Execute(null);
        }

    }
}