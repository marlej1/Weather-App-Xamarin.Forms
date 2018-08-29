using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppFomXamarin
{
  

    public class Metric : INotifyPropertyChanged
    {
        double myValue;
        public double Value
        {
            get { return myValue; }
            set
            {
                myValue = value;
                OnPropertyChanged(nameof(Value));

            }
        }
        string unit;
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                OnPropertyChanged(nameof(Unit));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Imperial : INotifyPropertyChanged
    {


        double myValue;
        public double Value
        {
            get { return myValue; }
            set
            {
                myValue = value;
                OnPropertyChanged(nameof(Value));

            }
        }
        string unit;
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                OnPropertyChanged(nameof(Unit));

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Temperature : INotifyPropertyChanged
    {
        Metric metric;
        public Metric Metric
        {
            get { return metric; }
            set
            {
                metric = value;
                OnPropertyChanged(nameof(Metric));

            }
        }


        Imperial imperial;
        public Imperial Imperial
        {
            get { return imperial; }
            set
            {
                imperial = value;
                OnPropertyChanged(nameof(Imperial));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class WeatherCondition : INotifyPropertyChanged
    {
        DateTime localObservationDateTime;
        public DateTime LocalObservationDateTime
        {
            get { return localObservationDateTime; }
            set
            {
                localObservationDateTime = value;
                OnPropertyChanged(nameof(LocalObservationDateTime));

            }
        }

        string weatherText;
        public string WeatherText
        {
            get { return weatherText; }
            set
            {
                weatherText = value;
                OnPropertyChanged(nameof(WeatherText));

            }
        }


        Temperature temperature;
        public Temperature Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged(nameof(Temperature));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
