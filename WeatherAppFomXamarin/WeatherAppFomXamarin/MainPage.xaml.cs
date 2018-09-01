using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherAppFomXamarin
{
	public partial class MainPage : ContentPage
	{

        // Constant strings  to build a query string used to connect to AccuWeather API service.

               public const string APPKEY = "HgVbSG7MlTqe51IhNuqeSJp6DT531FKS";
        public const string AUTOCOMPLETEURL  = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CONDTIONSURL = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";

		public MainPage()
		{
			InitializeComponent();      
            
          


        }
        // Search bar text changed event handler that's used to browse a list of available cities and pass the as an itemsource 
        //to the list view.
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {           


         ListofResults.ItemsSource = await GetMatchingLocationNames(e.NewTextValue);
        }


        //Item selected event handler. It navigates to the WeatherDetail Page and passes Result and WeatherCondition object.
        private async void ListofResults_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var city = e.SelectedItem as Result;
            if (city != null)
            {

                var weatherCondition =  await GetWeatherConditionAsync(city.Key);
                await Navigation.PushAsync(new WeatherDetailPage(city, weatherCondition));

            }
        }


        //Async method that retrieves list of all cities that match passed query string 
        async Task<List<Result>> GetMatchingLocationNames(string query)
        {
            List<Result> result = new List<Result>();
            string requestUrl = string.Format(AUTOCOMPLETEURL, APPKEY, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<Result>>(json);

            }

            return result;


        }


        //Async method the retrieves a  WeatherCondition object for the city with a matching cityKey.
        async Task<WeatherCondition> GetWeatherConditionAsync(string cityKey)
        {
            List<WeatherCondition> result = new List<WeatherCondition>();

            string requestUrl = string.Format(CONDTIONSURL, cityKey, APPKEY);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<WeatherCondition>>(json);

            }


            return result[0];
        }


        //Button Clicked handler that navigates to the page that displays list of favorites
        private async void Favorites_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritesPage());
        }
    }
}
