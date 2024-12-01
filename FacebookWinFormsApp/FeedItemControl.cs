using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FeedItemControl : UserControl
    {
        public FeedItemControl()
        {
            InitializeComponent();
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public void SetPostData(Post post)
        {
            descriptionLabel.Text = post.Description;
            linkLabel.Text = post.Link;
            datePostedLabel.Text = post.CreatedTime.ToString();
            PublisherNameLabel.Text = post.From.Name;
            publisherPictureBox.ImageLocation = post.From.PictureSmallURL;

            
            if (!string.IsNullOrEmpty(post.PictureURL))
            {
                // הצגת תמונה באמצעות WebBrowser
                string htmlImage = $@"
                <html>
                    <body style='margin:0; padding:0;'>
                        <img src='{post.PictureURL}' style='width:100%; height:100%; object-fit:cover;' />
                    </body>
                </html>";
                webBrowser.DocumentText = htmlImage;
            }
            else
            {
                // אם אין מדיה, הצג טקסט בלבד
                webBrowser.DocumentText = "<html><body>No media available</body></html>";
            }
        }

        public Color BackgroundColor { get; set; } = Color.WhiteSmoke; // צבע רקע
        public int CornerRadius { get; set; } = 20; // רדיוס הפינות

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // הגדרות ציור
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // יצירת צורה עם פינות מעוגלות
            using (GraphicsPath path = createRoundedRectanglePath(this.ClientRectangle, CornerRadius))
            {
                // מילוי הצורה בצבע רקע
                using (Brush brush = new SolidBrush(BackgroundColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private GraphicsPath createRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // צייר את הפינות המעוגלות
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // שמאל עליון
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // ימין עליון
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // ימין תחתון
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // שמאל תחתון

            path.CloseFigure();
            return path;
        }

        private void descriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                                 {
                                                     FileName = (sender as LinkLabel).Text,
                                                     UseShellExecute = true
                                                 });

            linkLabel.LinkVisited = true;
        }
    }
}
