using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;



namespace WeatherAppFomXamarin
{
    public class WeatherVM
    {
        
        
        public const string APPKEY = "HgVbSG7MlTqe51IhNuqeSJp6DT531FKS";
        public const string AUTOCOMPLETEURL  = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CONDTIONSURL = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";


        public WeatherCondition WeatherCondition { get; set; }
        public ObservableCollection<Result> Results { get; set; }
        private RefreshCommand refresh;

        public RefreshCommand RefreshWeather { get; set; }
      



        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                UpdateCities();

            }
        }

        private Result selectedResult;

        public Result SelectedResult
        {
            get { return selectedResult; }
            set {
                selectedResult = value;
               GetWeather();
            }
        }



        public WeatherVM()
        {
            WeatherCondition = new WeatherCondition();
            WeatherCondition.Temperature = new Temperature
            {
                Imperial = new Imperial { Value = 0 }
            };
            Results = new ObservableCollection<Result>()
            {
                new Result
                {
                    LocalizedName = "Krakow",
                    Key = "274455"
                    
                    
                },
                 new Result
                {
                    LocalizedName = "Warszawa"
                }
            };
            RefreshWeather = new RefreshCommand(this);
             
        }

        async Task<WeatherCondition> GetWeatherConditionAsync(string cityKey)
        {
            List<WeatherCondition> result = new List<WeatherCondition>();

            string requestUrl = string.Format(CONDTIONSURL, cityKey, APPKEY);
            using(HttpClient client =  new HttpClient())
            {
               var response = await client.GetAsync(requestUrl);
                string json = await response.Content.ReadAsStringAsync();

              result =  JsonConvert.DeserializeObject<List<WeatherCondition>>(json);

            }


            return result[0];
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
        private async void UpdateCities()
        {

            Results.Clear();
          var results = await GetMatchingLocationNames(Query);


            if (results != null)
            { 
            foreach (var item in results)
            {
                Results.Add(item);
            }
            }

          

        }

        private void Refresh()
        {
           throw new NotImplementedException();
        }
        public  void GetWeather()
        {
            //    var weather = await GetWeatherConditionAsync(selectedResult.Key);
            //    WeatherCondition.Temperature = weather.Temperature;
            //    WeatherCondition.WeatherText = weather.WeatherText;

            WeatherCondition.Temperature.Imperial.Value = 23;
            WeatherCondition.WeatherText = "Updated Sunny";


        }





    }
}
