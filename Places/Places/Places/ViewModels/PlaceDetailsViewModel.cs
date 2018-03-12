using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Places.ViewModels
{
    public class PlaceDetailsViewModel : BaseViewModel
    {
        PlaceDetails placeDetails;

        public Command LoadDetailsCommand;

        string id;

        public PlaceDetails PlaceDetails
        {
            get { return placeDetails; }
            set { SetProperty(ref placeDetails, value); }
        }

        public  PlaceDetailsViewModel(string id)
        {
            DataStore = new Services.PlacesAPI();
            PlaceDetails = new PlaceDetails();
            this.id = id;
            LoadDetailsCommand = new Command(async () => { await ExecuteLoadDetailsCommand(); });
           
        }

        async Task ExecuteLoadDetailsCommand()
        {
            var placeDetails = await DataStore.GetPlaceDetailsAsync(id);

            Device.BeginInvokeOnMainThread(() => {
                this.PlaceDetails.Address = placeDetails.Address;
                this.PlaceDetails.Icon = placeDetails.Icon;
                this.PlaceDetails = placeDetails;
            });
        }

        
    }
}
