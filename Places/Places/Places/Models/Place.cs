using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Places.Models
{
    public class Place
    {
        [JsonProperty(PropertyName = "formatted_address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty(PropertyName = "place_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class PlaceDetails : INotifyPropertyChanged
    {
        string address = string.Empty;
        Geometry geometry = null;
        string icon = string.Empty;
        string phoneNumber = string.Empty;
        string internaionalPhoneNumber = string.Empty;
        string name = string.Empty;


        [JsonProperty(PropertyName = "formatted_address")]
        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        
        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry {
            get { return geometry; }
            set { SetProperty(ref geometry, value); }
        }

        
        [JsonProperty(PropertyName = "icon")]
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        
        [JsonProperty(PropertyName = "formatted_phone_number")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { SetProperty(ref phoneNumber, value); }
        }

        
        [JsonProperty(PropertyName = "international_phone_number")]
        public string InternaionalPhoneNumber
        {
            get { return internaionalPhoneNumber; }
            set { SetProperty(ref internaionalPhoneNumber, value); }
        }

        
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,[CallerMemberName]string propertyName = "",Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public  class Geometry 
    {
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public string Longiude { get; set; }
    }

    public class PlacesResult
    {
        [JsonProperty(PropertyName ="results")]
        public List<Place> Places { get; set; }
    }

    public class PlaceDetailsResult
    {
        [JsonProperty(PropertyName = "result")]
        public PlaceDetails PlaceDetails { get; set; }
    }

    
}
