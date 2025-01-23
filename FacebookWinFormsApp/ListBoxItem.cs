
namespace BasicFacebookFeatures
{
    public class ListBoxItem
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }

        public ListBoxItem(string i_Name, string i_PictureUrl)
        {
            Name = i_Name;
            PictureUrl = i_PictureUrl;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
