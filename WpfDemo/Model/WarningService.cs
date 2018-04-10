using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public interface IWarningService
    {
        double WarningLimit { get; set; }
        

    }


    
    public class WarningService : IWarningService
    {
        private double _WarningLimit=100;
        public double WarningLimit { get => _WarningLimit;
            set {
                _WarningLimit = value;
                EventServer.Instance.TriggerEvent("LIMIT_CHANGE", new EventArgs());
            } }
    }
}
