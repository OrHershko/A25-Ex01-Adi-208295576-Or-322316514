using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class SortedPages : Form
    {
        public SortedPages()
        {
            InitializeComponent();
            sortedPagesListBox.DrawItem += FormMain.ListBox_DrawItem;
        }


        public void setSortedPagesListBox(List<Page> i_SortedLikedPages)
        {
            sortedPagesListBox.Items.Clear();

            foreach(var page in i_SortedLikedPages)
            {
                sortedPagesListBox.Items.Add(new ListBoxItem(page.Name, page.PictureSmallURL));
            }
        }
    }
}
