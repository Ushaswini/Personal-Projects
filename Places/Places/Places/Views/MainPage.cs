using Places.Views;
using System;

using Xamarin.Forms;

namespace Places
{
    public class MainPage : Page
    {
        public MainPage()
        {
            Page itemsPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new PlacesListViewPage())
                    {
                        Title = "Browse"
                    };                    
                    itemsPage.Icon = "tab_feed.png";
                    
                    break;
                default:
                    itemsPage = new PlacesListViewPage()
                    {
                         Title = "Browse"
                    };

                    
                    break;
            }

           
        }

        
    }
}
