using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FeedItemControl : UserControl
    {
        public FeedItemControl()
        {
            InitializeComponent();
        }

        public void SetPostData(Post i_Post)
        {
            descriptionLabel.Text = i_Post.Description;
            linkLabel.Text = i_Post.Link;
            datePostedLabel.Text = i_Post.CreatedTime.ToString();
            PublisherNameLabel.Text = i_Post.From.Name;
            publisherPictureBox.ImageLocation = i_Post.From.PictureSmallURL;

            if (!string.IsNullOrEmpty(i_Post.PictureURL))
            {
                string htmlImage = $@"
                <html>
                    <body style='margin:0; padding:0;'>
                        <img src='{i_Post.PictureURL}' style='width:100%; height:100%; object-fit:cover;' />
                    </body>
                </html>";
                webBrowser.DocumentText = htmlImage;
            }
            else
            {

                webBrowser.DocumentText = "<html><body>No media available</body></html>";
            }
        }

        public Color BackgroundColor { get; set; } = Color.WhiteSmoke; 
        public int CornerRadius { get; set; } = 20; 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = createRoundedRectanglePath(this.ClientRectangle, CornerRadius))
            {
                using (Brush brush = new SolidBrush(BackgroundColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private GraphicsPath createRoundedRectanglePath(Rectangle i_Rectangle, int i_Radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = i_Radius * 2;

            path.AddArc(i_Rectangle.X, i_Rectangle.Y, diameter, diameter, 180, 90); // שמאל עליון
            path.AddArc(i_Rectangle.Right - diameter, i_Rectangle.Y, diameter, diameter, 270, 90); // ימין עליון
            path.AddArc(i_Rectangle.Right - diameter, i_Rectangle.Bottom - diameter, diameter, diameter, 0, 90); // ימין תחתון
            path.AddArc(i_Rectangle.X, i_Rectangle.Bottom - diameter, diameter, diameter, 90, 90); // שמאל תחתון

            path.CloseFigure();
            return path;
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
