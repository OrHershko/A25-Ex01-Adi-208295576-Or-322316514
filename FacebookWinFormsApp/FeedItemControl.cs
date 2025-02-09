﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FeedItemControl : UserControl
    {
        private readonly BindingSource r_BindingSource;
        private readonly TextBox r_TextBoxEditDescription;

        public FeedItemControl(PostProxy i_PostProxy)
        {
            InitializeComponent();
            r_BindingSource = new BindingSource();
            r_BindingSource.DataSource = i_PostProxy;
            r_TextBoxEditDescription = new TextBox
                                         {
                                             Multiline = true,
                                             Visible = false,
                                             Width = descriptionLabel.Width,
                                             Height = 100,
                                             Location = descriptionLabel.Location,
                                             ScrollBars = ScrollBars.Vertical
                                         };

            descriptionLabel.Parent.Controls.Add(r_TextBoxEditDescription);
            r_TextBoxEditDescription.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        r_BindingSource.EndEdit();
                        r_TextBoxEditDescription.Visible = false;
                        descriptionLabel.Visible = true;
                        e.SuppressKeyPress = true;
                    }
                };

            setPostData(i_PostProxy);
        }

        private void setPostData(PostProxy i_PostProxy)
        {
            descriptionLabel.DataBindings.Clear();
            descriptionLabel.DataBindings.Add("Text", r_BindingSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            r_TextBoxEditDescription.DataBindings.Clear();
            r_TextBoxEditDescription.DataBindings.Add("Text", r_BindingSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            datePostedLabel.Text = i_PostProxy.Post.CreatedTime.ToString();
            PublisherNameLabel.Text = i_PostProxy.Post.From.Name;
            publisherPictureBox.ImageLocation = i_PostProxy.Post.From.PictureSmallURL;

            if (!string.IsNullOrEmpty(i_PostProxy.Post.PictureURL))
            {
                string htmlImage = $@"
        <html>
            <body style='margin:0; padding:0;'>
                <img src='{i_PostProxy.Post.PictureURL}' style='width:100%; height:100%; object-fit:cover;' />
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

            path.AddArc(i_Rectangle.X, i_Rectangle.Y, diameter, diameter, 180, 90);
            path.AddArc(i_Rectangle.Right - diameter, i_Rectangle.Y, diameter, diameter, 270, 90);
            path.AddArc(i_Rectangle.Right - diameter, i_Rectangle.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(i_Rectangle.X, i_Rectangle.Bottom - diameter, diameter, diameter, 90, 90);
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

        private void descriptionLabel_DoubleClick_1(object sender, EventArgs e)
        {
            descriptionLabel.Visible = false;
            r_TextBoxEditDescription.Visible = true;
            r_TextBoxEditDescription.Focus();
        }
    }
}
