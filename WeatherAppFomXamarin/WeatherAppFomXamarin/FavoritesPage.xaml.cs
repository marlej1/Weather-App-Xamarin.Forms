using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppFomXamarin.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherAppFomXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritesPage : ContentPage
	{

        private SQLiteConnection _connection;
        private ObservableCollection<Result> _resultstCollection;
        public FavoritesPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDB>().GetConnnection();
           
        }

        protected override void OnAppearing()
        {
            _connection.CreateTable<Result>();


            var results = _connection.Table<Result>().ToList();

            
            resultsListView.ItemsSource = results;

        }

       
    }
}