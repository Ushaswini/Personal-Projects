using Newtonsoft.Json;
using Places.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Places.Services
{
   public class PlacesAPI
    {        

        public async Task<List<Place>> GetPlacesAsync(string queryString)
        {
            List<Place> places = null;

            try
            {
                using(var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(String.Format(CONSTANTS.PLACES_URL, queryString));

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        places = JsonConvert.DeserializeObject<PlacesResult>(jsonResult).Places;
                    }

                    
                }
            }catch(Exception oExcep)
            {
                Debug.WriteLine(oExcep.Message.ToString());
            }

            return places;


        }

        public async Task<PlaceDetails> GetPlaceDetailsAsync(string placeId)
        {
            PlaceDetails placeDetails = null;

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(String.Format(CONSTANTS.PLACE_DETAILS_URL, placeId));

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        placeDetails = JsonConvert.DeserializeObject<PlaceDetailsResult>(jsonResult).PlaceDetails;
                    }
                }
            }catch(Exception oExcep)
            {
                Debug.WriteLine(oExcep.Message.ToString());
            }

            return placeDetails;


        }
    }
}
