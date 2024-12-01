using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class FriendItem
    {
        public string Name { get; set; } 
        public string PictureURL { get; set; }

        public FriendItem(string name, string pictureURL)
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
