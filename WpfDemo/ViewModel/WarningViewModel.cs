using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public class WarningViewModel:ObservableObject
    {
        private float _limit = 100;

        
        public string Limit
        {
            get
            {
                return _limit.ToString("0.00");
            
            }
            set
            {
                _limit = float.Parse(value);
                
            }
        } 
    }
}
