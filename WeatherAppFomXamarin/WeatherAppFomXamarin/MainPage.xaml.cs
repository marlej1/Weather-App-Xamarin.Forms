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

               public const string APPKEY = "HgVbSG7MlTqe51IhNuqeSJp6DT531FKS";
        public const string AUTOCOMPLETEURL  = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CONDTIONSURL = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";

		public MainPage()
		{
			InitializeComponent();      
            
          


        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {           


         ListofResults.ItemsSource = await GetMatchingLocationNames(e.NewTextValue);
        }

        private async void ListofResults_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var city = e.SelectedItem as Result;
            if (city != null)
            {

                var weatherCondition =  await GetWeatherConditionAsync(city.Key);
                await Navigation.PushAsync(new WeatherDetailPage(city, weatherCondition));

            }
        }

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

        private async void Favorites_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritesPage());
        }
    }
}
