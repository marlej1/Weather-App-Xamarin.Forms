using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WeatherAppFomXamarin
{
    class TemperatureValueToDescriptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            double tempValue = (double)value;

            if (tempValue >= 23)
                return string.Format("{0} it's hot", tempValue);
            else
                return string.Format("{0} it's cold", tempValue);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
