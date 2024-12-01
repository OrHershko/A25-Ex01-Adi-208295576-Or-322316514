using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        FacebookWrapper.LoginResult m_LoginResult;

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
                //    "user_posts"
                //);

                m_LoginResult = FacebookService.Connect(
                    "EAAMZB8alt53YBOxPQwM5JPl2ZBj0RBxt0sDZBB1nOFW5jTMubkghMgEownISqcMZAZAyCJCs7wBAKJMWEKbS7o8r0NrTAkLvB2k1InMdLWRyPQlqTciR7AhDTNbKh0NcyrzzOc5nLFNnSEfNawvqK8L2pnXUZAjJ5LcIqJhKPdqkLHXb6dwXPXmkFwlbF8BTUZCRnhYkypyjLATOjk1BTjPGhYTQEcg");

                if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
                {
                    buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                    buttonLogin.BackColor = Color.LightGreen;
                    pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;
                    await loadNewsFeedAsync();
                    await loadFriendsAsync();
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
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private async Task loadFriendsAsync()
        {
            await Task.Run(() =>
                {
                    foreach (var friend in m_LoginResult.LoggedInUser.Friends)
                    {
                        
                        friendsListBox.Invoke((Action)(() =>
                                                              {
                                                                  friendsListBox.Items.Add(new FriendItem(friend.Name, friend.PictureSmallURL));
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

        private void ListBoxFriends_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground(); // צייר את הרקע
            if (e.Index < 0) return;

            // שלוף את הפריט
            FriendItem friendItem = (FriendItem)((ListBox)sender).Items[e.Index];

            // צור PictureBox דינמי להצגת התמונה
            PictureBox pictureBox = new PictureBox
                                        {
                                            SizeMode = PictureBoxSizeMode.StretchImage,
                                            Width = 40,
                                            Height = 40,
                                            Location = new Point(e.Bounds.X, e.Bounds.Y), // מיקום בתוך השורה
                                            ImageLocation = friendItem.PictureURL // קישור לתמונה
                                        };

            // הוסף את ה-PictureBox ל-ListBox באופן זמני לציור
            ((Control)sender).Controls.Add(pictureBox);

            // צייר את שם החבר
            using (Font font = new Font("Arial", 10, FontStyle.Regular))
            {
                e.Graphics.DrawString(friendItem.Name, font, Brushes.Black, e.Bounds.X + 50, e.Bounds.Y + 10);
            }

            e.DrawFocusRectangle(); // צייר מסגרת כאשר הפריט בפוקוס
        }


    }
}
