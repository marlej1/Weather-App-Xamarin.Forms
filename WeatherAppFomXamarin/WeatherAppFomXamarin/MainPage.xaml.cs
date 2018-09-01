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
            
           // ListofResults.ItemsSource = GetResults();


        }


        private IEnumerable<Result> GetResults()
        {
            List<Result> results = new List<Result>
            {
                new Result
                {
                    LocalizedName="Krasnoyarsk",
                    Key = "293708",
                    Type = "City",
                    Rank = 21,
                    Country = new Country
                    {
                        ID = "RU",
                        LocalizedName = "Russia"
                    },
                    AdministrativeArea = new AdministrativeArea
                    {
                        ID = "KYA",
                        LocalizedName = "Krasnoyarsk"
                    }


                },
                 new Result
                {
                    LocalizedName="Krakow",
                    Key = "274455",
                    Type = "City",
                    Rank = 3,
                    Country = new Country
                    {
                        ID = "Po",
                        LocalizedName = "Poland"
                    },
                    AdministrativeArea = new AdministrativeArea
                    {
                        ID = "Mal",
                        LocalizedName = "Malopolska"
                    }


                },

                     new Result
                {
                    LocalizedName="Warszawa",
                    Key = "274663",
                    Type = "City",
                    Rank = 3,
                    Country = new Country
                    {
                        ID = "Po",
                        LocalizedName = "Poland"
                    },
                    AdministrativeArea = new AdministrativeArea
                    {
                        ID = "Mal",
                        LocalizedName = "Mazowieckie"
                    }


                },

                            new Result
                {
                    LocalizedName="Warrington",
                    Key = "331331",
                    Type = "City",
                    Rank = 3,
                    Country = new Country
                    {
                        ID = "UK",
                        LocalizedName = "United Kingdom"
                    },
                    AdministrativeArea = new AdministrativeArea
                    {
                        ID = "WRT",
                        LocalizedName = "Warrington"
                    }


                }
            };

           


            return results;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {           

        // ListofResults.ItemsSource = GetResults().Where(r => r.LocalizedName.Contains(e.NewTextValue)).ToList();

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

    }
}
