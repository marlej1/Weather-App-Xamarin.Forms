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

        private SQLiteConnection connection;

        public WeatherDetailPage()
        {
            InitializeComponent();


            
         

        }
		public WeatherDetailPage (Result city, WeatherCondition weatherCondtion)
		{
			InitializeComponent ();
            connection = DependencyService.Get<ISQLiteDB>().GetConnnection();


            //TemperatureLbl.Text = weatherCondtion.Temperature.Metric.Value.ToString();
            //CityNameLbl.Text = city.LocalizedName;
            //WeatherTextLbl.Text = weatherCondtion.WeatherText;




        }

        protected override void OnAppearing()
        {
            
            connection.CreateTable<Result>();
        }

        



    }
}