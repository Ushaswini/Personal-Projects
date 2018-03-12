using Places.Models;
using Places.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Places.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacesListViewPage : ContentPage
    {
        PlacesViewModel viewModel;

        public ListView ListView;

        public PlacesListViewPage()
        {
            InitializeComponent();

            ListView = PlacesListView;

            BindingContext = viewModel = new PlacesViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var place = args.SelectedItem as Place;
            if (place == null)
                return;

            await Navigation.PushAsync(new PlaceDetailsPage(place.Id));

            // Manually deselect item
            PlacesListView.SelectedItem = null;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (viewModel.PlacesToDisplay.Count == 0)
        //        viewModel.LoadPlacesCommand.Execute(null);
        //}

        private void searchBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.LoadPlacesCommand.Execute(input.Text.ToString());
        }
    }
}
