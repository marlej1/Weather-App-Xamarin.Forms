using System;
using System.Collections.Generic;
using System.Text;
using Android.OS;
using SQLite;
using SQLitePCL;

namespace WeatherAppFomXamarin.Data
{
     public interface ISQLiteDB
    {

        SQLiteConnection GetConnnection();
    }
}
