using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppFomXamarin
{
  

    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        [Ignore]
        public Country Country { get; set; }
        [Ignore]
        public AdministrativeArea AdministrativeArea { get; set; }
    }


}
