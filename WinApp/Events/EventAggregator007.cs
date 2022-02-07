using Prism.Events;
using System;
using System.Collections.Concurrent;

namespace WinApp.Events
{
    public class EventAggregator007 : IEventAggregator
    {
        private ConcurrentDictionary<Type, EventBase> _events = new ConcurrentDictionary<Type, EventBase>();

        public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
        {
            return (TEventType)_events.GetOrAdd(typeof(TEventType), new TEventType());
        }
    }
}
