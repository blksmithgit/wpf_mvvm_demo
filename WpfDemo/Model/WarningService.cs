using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public interface IWarningService
    {
        float WarningLimit { get; set; }

    }
    public class WarningService : IWarningService
    {
        private float _WarningLimit;
        public float WarningLimit { get => _WarningLimit;
            set {
                _WarningLimit = value;
                EventServer.Instance.TriggerEvent("LIMIT_CHANGE", new EventArgs());
            } }
    }
}
