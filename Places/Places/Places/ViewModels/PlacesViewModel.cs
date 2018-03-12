using Places.Models;
using Places.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Places.ViewModels
{
    public class PlacesViewModel : BaseViewModel
    {
        public ObservableCollection<Place> PlacesToDisplay { get; set; }  

        public string inputQuery { get; set; }        

        public Command LoadPlacesCommand { get; set; }

        public PlacesViewModel()
        {
            PlacesToDisplay = new ObservableCollection<Place>();
            DataStore = new PlacesAPI();
            LoadPlacesCommand = new Command(async () => { await ExecuteLoadPlacesCommand(); });
        }

        async Task ExecuteLoadPlacesCommand()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var places = await DataStore.GetPlacesAsync(inputQuery);

                Device.BeginInvokeOnMainThread(() => {
                    PlacesToDisplay.Clear();
                    foreach (var place in places)
                    {
                        PlacesToDisplay.Add(place);
                    }
                });                    

                
            }catch(Exception oExcep)
            {
                Debug.WriteLine(oExcep.Message.ToString());
            }

            finally
            {
                IsBusy = false;
            }
           
        }
       
    }
}
