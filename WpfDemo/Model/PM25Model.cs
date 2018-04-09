using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public class PM25Data
    {
        public string CityName { get; set; }
        public double Pm25 { get; set; }
        public PM25Status Status { get; set; }
        
    }

    public enum PM25Status { NORMAL,WARNING}
}
