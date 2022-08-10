using Newtonsoft.Json;
using RestSharp;
using Spectrum.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spectrum
{
    public partial class MainPage : ContentPage
    {
        List<Store> Stores = new List<Store>();

        public MainPage()
        {
            InitializeComponent();

            //Deserialize the response data from Spectrum.com.
            Stores = JsonConvert.DeserializeObject<StoreResponseData>(GetStores()).response.locations;

            //Populate our list.
            storeList.ItemsSource = Stores;
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Launch the details page for the selected store.
            var store = e.Item as Store;
            var storeDetails = new StoreDetails
            {
                BindingContext = store
            };

            Navigation.PushAsync(storeDetails);

            ((ListView)sender).SelectedItem = null;
        }

        void SearchButtonPressed(object sender, System.EventArgs e)
        {
            //Filter the stores list on zip code. Could have done more here, but figured this would be simplest for the sake of this demo.
            var storesSearched = Stores.Where(c => c.zip.Contains(storesSearchBar.Text));
            storeList.ItemsSource = storesSearched;
        }

        //Copied the cURL info from the Chrome dev tools on Spectrum.com so that I could replicate getting stores instead of using dummy data.
        public string GetStores()
        {
            try
            {
                var client = new RestClient("https://www.spectrum.com/bin/spectrum/storeLocator?address=75056&miles=100&maxStoresDisplayed=50&filters=%5B%7B%22closed%22%3A%22false%22%7D%5D");
                client.Options.MaxTimeout = -1;
                var request = new RestRequest();
                request.AddHeader("authority", "www.spectrum.com");
                request.AddHeader("accept", "application/json, text/javascript, */*; q=0.01");
                request.AddHeader("accept-language", "en-US,en;q=0.9,ar;q=0.8");
                request.AddHeader("dnt", "1");
                request.AddHeader("referer", "https://www.spectrum.com/stores");
                request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"104\", \" Not A;Brand\";v=\"99\", \"Google Chrome\";v=\"104\"");
                request.AddHeader("sec-ch-ua-mobile", "?0");
                request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");
                request.AddHeader("x-requested-with", "XMLHttpRequest");
                var response = client.Execute(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error encountered while in stores REST request.", ex.Message);
            }

            return null;
        }
    }
}
