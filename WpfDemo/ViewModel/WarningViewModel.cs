using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemo
{
    public class WarningViewModel : ObservableObject
    {
        

        public WarningViewModel()
        {
            Limit = Service.WarningLimit.ToString("0.00");
        }



        public string Limit
        {
            get;set;
        }
     


        public ICommand UpdateLimitCommand
        {
            get
            {
                return new DelegateCommand(UpdateLimit);
            }
        }

        IWarningService Service
        {
            get
            {
                return IOCService.Instance.QueryService("WARN_SERVICE") as IWarningService;
            }
        }

        void UpdateLimit()
        {
            Service.WarningLimit = double.Parse(Limit);
        }
    }
}
