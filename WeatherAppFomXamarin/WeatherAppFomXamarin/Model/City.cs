using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppFomXamarin
{
    public class Country :INotifyPropertyChanged
    {

        string id;
        public string ID {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));

            }
        }

        string localizedName;
        public string LocalizedName
        {
            get
            {
                return localizedName;
            }
            set
            {
                localizedName = value;
                OnPropertyChanged(nameof(LocalizedName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class AdministrativeArea : INotifyPropertyChanged
    {
        string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));

            }
        }
        string localizedName;
        public string LocalizedName
        {
            get
            {
                return localizedName;
            }
            set
            {
                localizedName = value;
                OnPropertyChanged(nameof(LocalizedName));
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class City : INotifyPropertyChanged
    {
        string key;
        public string Key
        {
            get { return key; }
            set {
                key = value;
                OnPropertyChanged(nameof(Key));
            }
        }
        string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        int rank;
        public int Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged(nameof(Rank));
            }
        }

        string localizedName;
        public string LocalizedName
        {
            get
            {
                return localizedName;
            }
            set
            {
              
                localizedName = value;
                OnPropertyChanged(nameof(LocalizedName));
            }
        }

        Country country;
        public Country Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
               
            }
        }


        AdministrativeArea administrativeArea;
        public AdministrativeArea AdministrativeArea
        {
            get { return administrativeArea; }
            set
            {
                administrativeArea = value;
                OnPropertyChanged(nameof(AdministrativeArea));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
