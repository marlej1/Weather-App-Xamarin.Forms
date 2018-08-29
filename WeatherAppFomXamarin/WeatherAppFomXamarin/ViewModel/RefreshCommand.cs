using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherAppFomXamarin
{
    public class RefreshCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        private WeatherVM _vm;
        public RefreshCommand(WeatherVM vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.GetWeather();
        }
    }
}
