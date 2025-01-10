using System;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class EventProxy
    {
        public Event Event { get; set; }

        public EventProxy(Event i_Event)
        {
            Event = i_Event;
        }

        public EventProxy(){}

        public override string ToString()
        {
            string dateDisplay = Event.StartTime.HasValue ? Event.StartTime.Value.ToString("yyyy-MM-dd HH:mm") : "Unknown";
            return $"{Event.Name} | {Event.Location} | {dateDisplay}";
        }
    }
}
