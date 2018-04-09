using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo
{
    public class EventServer : IEventServer
    {
        Dictionary<string, List<Action<EventArgs>>> _handlers = new Dictionary<string, List<Action<EventArgs>>>();

        private static EventServer _Instance = null;

        public static EventServer Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new EventServer();
                return _Instance;
            }
        }

        private EventServer()
        { }

       public void RegisterEventListener(string eventtype,Action<EventArgs> eventhandler)
        {
            List<Action<EventArgs>> list=null;
            if (!_handlers.TryGetValue(eventtype,out list))
            { 
                list = new List<Action<EventArgs>>();
                _handlers.Add(eventtype, list);
            }
            list.Add(eventhandler);

        }

        public void TriggerEvent(string eventtype,EventArgs e)
        {
            var list = _handlers[eventtype];
            if (list != null)
            {
                foreach (var handler in list)
                    handler.Invoke(e);
            }
           
        }

    }
}
