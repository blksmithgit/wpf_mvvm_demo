using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public class IOCService
    {
        static IOCService _Instance = null;
        public static IOCService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new IOCService();
                return _Instance;
            }
        }

        Dictionary<string, object> _services = new Dictionary<string, object>();
        public void RegisterService(string servicename ,object service)
        {
            _services[servicename] = service;
        }

        public object QueryService(string serviceaname)
        {
            return _services[serviceaname];
        }

        private IOCService()
        {

        }
    }
}
