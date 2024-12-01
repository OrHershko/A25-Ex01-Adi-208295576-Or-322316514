using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class ListBoxItem
    {
        public string Name { get; set; } 
        public string PictureURL { get; set; }

        public ListBoxItem(string name, string pictureURL)
        {
            Name = name;
            PictureURL = pictureURL;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
