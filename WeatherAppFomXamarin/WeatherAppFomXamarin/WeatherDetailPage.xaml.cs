using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherAppFomXamarin.Data;
using SQLite;

namespace WeatherAppFomXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherDetailPage : ContentPage
	{

        private SQLiteConnection _connection;
        Result _city;


        public WeatherDetailPage()
        {
            InitializeComponent();
            

        }
        public WeatherDetailPage (Result city, WeatherCondition weatherCondtion)
		{
			InitializeComponent ();


            _connection = DependencyService.Get<ISQLiteDB>().GetConnnection();

            _city = city;

            TemperatureLbl.Text = weatherCondtion.Temperature.Metric.Value.ToString();
            CityNameLbl.Text = _city.LocalizedName;
            WeatherTextLbl.Text = weatherCondtion.WeatherText;
            




        }

        protected override void OnAppearing()
        {
            
            _connection.CreateTable<Result>();
           






        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var result = _connection.Table<Result>().ToList().SingleOrDefault(r => r.Key == _city.Key);

            if (result == null)
            {
                _connection.Insert(_city);
                DisplayAlert("Favorites", _city.LocalizedName + " was added to to the favorites", "ok");
            }
            else
            {
                _connection.Delete(result);
                DisplayAlert("Favorites", result.LocalizedName + " was removed from the favorites", "ok");
            }
              
           
                
                
        }
    }
}