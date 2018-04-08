using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{

    

    public class MainViewModel : ObservableObject
    {
        public Device device = new Device();
        public string Name {
                get { return device.Name; }
            set { device.Name = value; }
        }
        public int Status {
            get
            {
                return device.Status;
            }
            set
            {
                device.Status = value;
            }
        }

        
        
        
    }
}
