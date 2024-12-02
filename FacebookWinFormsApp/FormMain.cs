using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using Facebook;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            hideComponents();
        }

        FacebookWrapper.LoginResult m_LoginResult;

        private void hideComponents()
        {
            friendsListBox.Hide();
            friendsLabel.Hide();
            albumsListBox.Hide();
            albumsLabel.Hide();
            likedPagesListBox.Hide();
            likedPagesLabel.Hide();
            flowLayoutPanelFeed.Hide();
            usernameLabel.Hide();
        }

        private void showComponents()
        {
            friendsListBox.Show();
            friendsLabel.Show();
            albumsListBox.Show();
            albumsLabel.Show();
            likedPagesListBox.Show();
            likedPagesLabel.Show();
            flowLayoutPanelFeed.Show();
            usernameLabel.Show();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (m_LoginResult == null)
            {
                await loginAsync();
            }
        }

        private async Task loginAsync()
        {
            try
            {
                //m_LoginResult = FacebookService.Login(
                //    "913632580724598",
                //    "email",
                //    "public_profile",
                //    "user_friends",
                //    "user_likes",
                //    "user_posts",
                //    "user_photos"
                //);

                string id = "EAAMZB8alt53YBO3BZBZCrOQaqgPyXOVEnlze7lsAbWXrQqMI2CfvlZBS1QOLeHxkWPYEAKzdlOVK0Sa52WrgiFZC2nb0RR0trZCQP1SUYY7xMQV6rUpyl90eZCCcnYq3QdiD7VUb382VihCK77EtY3kCCMneVQ9TVZAQr8jcu5wk9rdYrEaiSC2SrEP27daGItxunREwJO7OdMACuclKvZC2bbsd6F82DCkUZADi00bgZDZD";

                m_LoginResult = FacebookService.Connect(id);

                if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
                {
                    buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                    usernameLabel.Text = m_LoginResult.LoggedInUser.Name;
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;
                    friendsListBox.DrawItem += ListBox_DrawItem;
                    albumsListBox.DrawItem += ListBox_DrawItem;
                    likedPagesListBox.DrawItem += ListBox_DrawItem;
                    showComponents();
                    //await loadNewsFeedAsync();
                    //await loadFriendsAsync();
                    //await loadAlbumsAsync();
                    //await loadPagesAsync();
                }
                else
                {
                    MessageBox.Show($"Login failed: {m_LoginResult.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            hideComponents();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            pictureBoxProfile.ImageLocation = null;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private async Task loadFriendsAsync()
        {
            await PopulateListBoxAsync(
                friendsListBox,
                m_LoginResult.LoggedInUser.Friends,
                (listBox, friend) =>
                    {
                        listBox.Items.Add(new ListBoxItem(friend.Name, friend.PictureSmallURL));
                    });
        }

        private async Task loadAlbumsAsync()
        {
            await PopulateListBoxAsync(
                albumsListBox,
                m_LoginResult.LoggedInUser.Albums,
                (listBox, album) =>
                    {
                        listBox.Items.Add(new ListBoxItem(album.Name, album.PictureSmallURL));
                    });
        }

        private async Task loadPagesAsync()
        {
            await PopulateListBoxAsync(
                likedPagesListBox,
                m_LoginResult.LoggedInUser.LikedPages,
                (listBox, page) =>
                    {
                        listBox.Items.Add(new ListBoxItem(page.Name, page.PictureSmallURL));
                    });
        }


        private async Task PopulateListBoxAsync<T>(ListBox listBox, IEnumerable<T> items, Action<ListBox, T> addAction)
        {
            await Task.Run(() =>
                {
                    foreach (var item in items)
                    {
                        listBox.Invoke((Action)(() =>
                                                       {
                                                           addAction(listBox, item); // מבצע את הפעולה על כל פריט
                                                       }));
                    }
                });
        }



        private async Task loadNewsFeedAsync()
        {
            try
            {
                if (m_LoginResult?.LoggedInUser == null)
                {
                    MessageBox.Show("User is not logged in.");
                    return;
                }

                IEnumerable<Post> posts = m_LoginResult.LoggedInUser.Posts;
                flowLayoutPanelFeed.Controls.Clear();

                foreach (var post in posts)
                {
                    if (!string.IsNullOrEmpty(post.Description))
                    {
                        FeedItemControl feedItemControl = new FeedItemControl();

                        feedItemControl.SetPostData(post);
                        
                        flowLayoutPanelFeed.Controls.Add(feedItemControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the News Feed: {ex.Message}");
            }
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground(); // צייר את הרקע
            if (e.Index < 0) return;

            // שלוף את הפריט
            ListBoxItem listBoxItem = (ListBoxItem)((ListBox)sender).Items[e.Index];

            // צור PictureBox דינמי להצגת התמונה
            PictureBox pictureBox = new PictureBox
                                        {
                                            SizeMode = PictureBoxSizeMode.StretchImage,
                                            Width = 40,
                                            Height = 40,
                                            Location = new Point(e.Bounds.X, e.Bounds.Y), // מיקום בתוך השורה
                                            ImageLocation = listBoxItem.PictureURL // קישור לתמונה
                                        };

            // הוסף את ה-PictureBox ל-ListBox באופן זמני לציור
            ((Control)sender).Controls.Add(pictureBox);

            // צייר את שם החבר
            using (Font font = new Font("Arial", 10, FontStyle.Regular))
            {
                e.Graphics.DrawString(listBoxItem.Name, font, Brushes.Black, e.Bounds.X + 50, e.Bounds.Y + 10);
            }

            e.DrawFocusRectangle(); // צייר מסגרת כאשר הפריט בפוקוס
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void friendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void postStatusButton_Click(object sender, EventArgs e)
        {
            try
            {
                FacebookWrapper.ObjectModel.Status postedStatus = m_LoginResult.LoggedInUser.PostStatus(postTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkWeatherButton_Click(object sender, EventArgs e)
        {
            WeatherCheckWindow weatherCheck = new WeatherCheckWindow();

            weatherCheck.setEventsList(m_LoginResult.LoggedInUser.Events);

            weatherCheck.ShowDialog();

        }

    }
}
