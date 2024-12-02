using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class FacebookEvent
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        
        public String Location { get; set; }

        public FacebookEvent(string i_Name, DateTime? i_Date, string i_Location)
        {
            Name = i_Name;
            Date = i_Date;
            Location = i_Location;
        }
        public override string ToString()
        {
            string dateDisplay = Date.HasValue ? Date.Value.ToString("yyyy-MM-dd HH:mm") : "Unknown";
            return $"{Name} | {Location} | {dateDisplay}";
        }
    }
}
