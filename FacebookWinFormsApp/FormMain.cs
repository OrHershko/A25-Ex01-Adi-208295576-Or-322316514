using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;


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

        private FacebookWrapper.LoginResult m_LoginResult;

        private void hideComponents()
        {
            listBoxFriends.Hide();
            labelFriends.Hide();
            listBoxAlbums.Hide();
            labelAlbums.Hide();
            listBoxLikedPages.Hide();
            labelLikedPages.Hide();
            flowLayoutPanelFeed.Hide();
            usernameLabel.Hide();
            buttonSortPage.Hide();
            buttonCheckWeather.Hide();
            textBoxPost.Hide();
            buttonPostStatus.Hide();
        }

        private void showComponents()
        {
            listBoxFriends.Show();
            labelFriends.Show();
            listBoxAlbums.Show();
            labelAlbums.Show();
            listBoxLikedPages.Show();
            labelLikedPages.Show();
            flowLayoutPanelFeed.Show();
            usernameLabel.Show();
            buttonSortPage.Show();
            buttonCheckWeather.Show();
            textBoxPost.Show();
            buttonPostStatus.Show();
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

                m_LoginResult = FacebookService.Connect(
                    "EAAMZB8alt53YBO7iI0LDzawQ3h4iLNLQJUcGTw0EyNeKTpkqUXsYsdnxMZAccEHPZBZCLepPYCaC6nZCtZC88okksDFMlJKEuO0gX29g4EZBxjWGtXnFl2KXZCrCcLRvyaGOnzHAZBR0SEX4CzW7DcvjHcS8VbmODaRJ3ZCyYSwRMIj0ZC5tdEhTe2d6uNsSjZCeljHQeYHbRJQh1lmrnsFFbBkzLLLHLnoVAdfETiFWwQZDZD");

                if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
                {
                    buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                    usernameLabel.Text = m_LoginResult.LoggedInUser.Name;
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;
                    listBoxFriends.DrawItem += ListBox_DrawItem;
                    listBoxAlbums.DrawItem += ListBox_DrawItem;
                    listBoxLikedPages.DrawItem += ListBox_DrawItem;
                    showComponents();
                    loadNewsFeedAsync();
                    await loadFriendsAsync();
                    await loadAlbumsAsync();
                    await loadPagesAsync();
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
            await populateListBoxAsync(
                listBoxFriends,
                m_LoginResult.LoggedInUser.Friends,
                (listBox, friend) =>
                    {
                        listBox.Items.Add(new ListBoxItem(friend.Name, friend.PictureSmallURL));
                    });
        }

        private async Task loadAlbumsAsync()
        {
            await populateListBoxAsync(
                listBoxAlbums,
                m_LoginResult.LoggedInUser.Albums,
                (listBox, album) =>
                    {
                        listBox.Items.Add(new ListBoxItem(album.Name, album.PictureSmallURL));
                    });
        }

        private async Task loadPagesAsync()
        {
            await populateListBoxAsync(
                listBoxLikedPages,
                m_LoginResult.LoggedInUser.LikedPages,
                (listBox, page) =>
                    {
                        listBox.Items.Add(new ListBoxItem(page.Name, page.PictureSmallURL));
                    });
        }


        private async Task populateListBoxAsync<T>(ListBox listBox, IEnumerable<T> items, Action<ListBox, T> addAction)
        {
            await Task.Run(() =>
                {
                    foreach (var item in items)
                    {
                        listBox.Invoke((Action)(() =>
                                                       {
                                                           addAction(listBox, item); 
                                                       }));
                    }
                });
        }

        private void loadNewsFeedAsync()
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

        public static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground(); 
            if (e.Index < 0) return;

            ListBoxItem listBoxItem = (ListBoxItem)((ListBox)sender).Items[e.Index];
            PictureBox pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 40,
                Height = 40,
                Location = new Point(e.Bounds.X, e.Bounds.Y), 
                ImageLocation = listBoxItem.PictureURL 
            };

            ((Control)sender).Controls.Add(pictureBox);
            using (Font font = new Font("Arial", 10, FontStyle.Regular))
            {
                e.Graphics.DrawString(listBoxItem.Name, font, Brushes.Black, e.Bounds.X + 50, e.Bounds.Y + 10);
            }

            e.DrawFocusRectangle(); 
        }


        private void postStatusButton_Click(object sender, EventArgs e)
        {
            try
            {
                FacebookWrapper.ObjectModel.Status postedStatus = m_LoginResult.LoggedInUser.PostStatus(textBoxPost.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkWeatherButton_Click(object sender, EventArgs e)
        {
            FormWeatherCheck weatherCheck = new FormWeatherCheck();

            weatherCheck.SetEventsList(m_LoginResult.LoggedInUser.Events);
            weatherCheck.ShowDialog();
        }

        private void sortedPagesButton_Click(object sender, EventArgs e)
        {
            var sortedLikedPages = m_LoginResult.LoggedInUser.LikedPages.OrderBy(page => page.LikesCount).ToList();
            formSortedPages sortedPagesWindow = new formSortedPages();

            sortedPagesWindow.InitSortedPagesWindow(sortedLikedPages);
            sortedPagesWindow.ShowDialog();
        }

    }
}
