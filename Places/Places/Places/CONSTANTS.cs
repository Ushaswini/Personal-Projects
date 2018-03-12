using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places
{
    class CONSTANTS
    {

         public static string API_KEY = "AIzaSyBNGYiUhSzo5eMA9X8yaPR-b5fnv8x6BWI";
        public static string BASE_URL = "https://maps.googleapis.com/maps/api/place/";
        public static string PLACES_URL = BASE_URL + "textsearch/json?query={0}&key=" + API_KEY;
        public static string PLACE_DETAILS_URL = BASE_URL + "details/json?placeid={0}&key=" + API_KEY;
       
    }
}
