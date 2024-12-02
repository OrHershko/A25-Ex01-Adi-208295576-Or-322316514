using System;

namespace BasicFacebookFeatures
{
    public class FacebookEventWrapper
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public String Location { get; set; }

        public FacebookEventWrapper(string i_Name, DateTime? i_Date, string i_Location)
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
