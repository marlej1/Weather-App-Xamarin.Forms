using System;
using System.IO;
using SQLite;
using WeatherAppFomXamarin.Data;
using WeatherAppFomXamarin.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDB))]

namespace WeatherAppFomXamarin.Droid.Data
{
    class SQLiteDB : ISQLiteDB
    {
        public SQLiteConnection GetConnnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySqlite.db3");

            return new SQLiteConnection(path);
        }
    }
}