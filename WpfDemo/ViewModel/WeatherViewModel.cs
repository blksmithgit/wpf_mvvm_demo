using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemo
{
    public class WeatherViewModel:ObservableObject
    {
        string _cityName = "北京";
        string _pm25 = "10";
        string _statuscolor = "Green";


        public WeatherViewModel()
        {
            EventServer.Instance.RegisterEventListener("DATA_CHANGE", DealDataChange);
           
        }


        private void DealDataChange(EventArgs e)
        {
            IDataServer service = IOCService.Instance.QueryService("DATA_SERVICE") as IDataServer;
            var data = service.GetData();
            CityName = data.CityName;
            PM25 = data.Pm25.ToString("0.00");

        }

        public string CityName
        {
            get
            {
                return _cityName;
            }
            private set
            {
                if (_cityName == value)
                    return;
                _cityName = value;
                RaisePropertyChangedEvent(nameof(CityName));
            }
        }

     
        public string PM25
        {
            get
            {
                return _pm25;
            }
            private set
            {
                if (_pm25 == value)
                    return;
                _pm25 = value;
                RaisePropertyChangedEvent(nameof(PM25));
            }
        }

        public string StatusColor
        {
            get
            {
                return _statuscolor;
            }
            set
            {
                if (_statuscolor == value)
                    return;
                _statuscolor = value;
                RaisePropertyChangedEvent(nameof(StatusColor));
            }
        }


        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(RefreshData);
            }
        }

        private void RefreshData()
        {
            IDataServer service =  IOCService.Instance.QueryService("DATA_SERVICE") as IDataServer;
            service.Refresh();

        }
    }
}
