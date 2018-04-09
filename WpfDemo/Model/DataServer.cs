using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public class DataServer : IDataServer
    {
        PM25Data _Data = new PM25Data();


        public DataServer()
        {
          
            EventServer.Instance.RegisterEventListener("LIMIT_CHANGE", ChangeLimit);
        }


        public void ChangeLimit(EventArgs e)
        {
            _Data.Status = CalcStatus(_Data.Pm25);

            EventServer.Instance.TriggerEvent("DATA_CHANGE", new EventArgs { });
        }

        public PM25Data GetData()
        {
            return _Data;
        }

        Random random = new Random(100);
        public void Refresh()
        {
            _Data.Pm25 = random.NextDouble() * 200;
            _Data.Status = CalcStatus(_Data.Pm25);

            EventServer.Instance.TriggerEvent("DATA_CHANGE", new EventArgs { });

        }

        private PM25Status CalcStatus(double pm25)
        {
            IWarningService limitService = IOCService.Instance.QueryService("WARN_SERVICE") as IWarningService;
            double limit = limitService.WarningLimit;
            if (pm25 > limit)
                return PM25Status.WARNING;
            else
                return PM25Status.NORMAL;
           
        }
    }
}
