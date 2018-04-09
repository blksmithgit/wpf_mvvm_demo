using System;

namespace WpfDemo
{
    public interface IEventServer
    {
        void RegisterEventListener(string eventtype, Action<EventArgs> eventhandler);
        void TriggerEvent(string eventtype, EventArgs e);
    }
}