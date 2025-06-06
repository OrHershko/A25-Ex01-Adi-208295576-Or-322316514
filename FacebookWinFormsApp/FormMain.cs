﻿using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (LoggedInUserSingleton.Instance.LoginResult == null)
            {
                new Thread(loginAsync).Start();
            }
        }

        private void loginAsync()
        {
            try
            {
                //LoggedInUserSingleton.Instance.LoginResult = FacebookService.Login(
                //    "913632580724598",
                //    "email",
                //    "public_profile",
                //    "user_friends",
                //    "user_likes",
                //    "user_posts",
                //    "user_photos"
                //);

                LoggedInUserSingleton.Instance.LoginResult = FacebookService.Connect("");

                if (string.IsNullOrEmpty(LoggedInUserSingleton.Instance.LoginResult.ErrorMessage))
                {
                    this.Invoke(new Action(updateUiAfterLogin));
                    new Thread(loadNewsFeedAsync).Start();
                    new Thread(loadFriendsAsync).Start();
                    new Thread(loadAlbumsAsync).Start();
                    new Thread(loadPagesAsync).Start();
                }
                else
                {
                    MessageBox.Show($"Login failed: {LoggedInUserSingleton.Instance.LoginResult.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void updateUiAfterLogin()
        {
            buttonLogin.Text = $"Logged in as {LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.Name}";
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Enabled = false;
            usernameLabel.Text = LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.Name;
            pictureBoxProfile.ImageLocation = LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.PictureNormalURL;
            buttonLogout.Enabled = true;
            listBoxFriends.DrawItem += ListBox_DrawItem;
            listBoxAlbums.DrawItem += ListBox_DrawItem;
            listBoxLikedPages.DrawItem += ListBox_DrawItem;
            showComponents();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            hideComponents();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            pictureBoxProfile.ImageLocation = null;
            LoggedInUserSingleton.Instance.LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void loadFriendsAsync()
        {
            populateListBoxAsync(
                listBoxFriends,
                LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.Friends,
                (i_ListBox, i_Friend) =>
                    {
                        i_ListBox.Items.Add(new ListBoxItem(i_Friend.Name, i_Friend.PictureSmallURL));
                    });

        }

        private void loadAlbumsAsync()
        {
            populateListBoxAsync(
                listBoxAlbums,
                LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.Albums,
                (i_ListBox, i_Album) =>
                    {
                        i_ListBox.Items.Add(new ListBoxItem(i_Album.Name, i_Album.PictureSmallURL));
                    });
        }

        private void loadPagesAsync()
        {
            populateListBoxAsync(
                listBoxLikedPages,
                LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.LikedPages,
                (i_ListBox, i_Page) =>
                    {
                        i_ListBox.Items.Add(new ListBoxItem(i_Page.Name, i_Page.PictureSmallURL));
                    });
        }


        private void populateListBoxAsync<T>(ListBox i_ListBox, IEnumerable<T> i_Items, Action<ListBox, T> i_AddAction)
        {
            foreach (var item in i_Items)
            {
                i_ListBox.Invoke(new Action(() =>
                                                 {
                                                     i_AddAction(i_ListBox, item);
                                                 }));
            }
        }

        private void loadNewsFeedAsync()
        {
            try
            {
                if (LoggedInUserSingleton.Instance.LoginResult?.LoggedInUser == null)
                {
                    MessageBox.Show("User is not logged in.");
                    return;
                }

                IEnumerable<Post> posts = LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.Posts;
                flowLayoutPanelFeed.Invoke(new Action(() => flowLayoutPanelFeed.Controls.Clear()));
                foreach (var post in posts)
                {
                    flowLayoutPanelFeed.Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(post.Description))
                            {
                                FeedItemControl feedItemControl = new FeedItemControl(new PostProxy(post));
                                flowLayoutPanelFeed.Controls.Add(feedItemControl);
                            }
                        }));

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
                ImageLocation = listBoxItem.PictureUrl 
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
                LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.PostStatus(textBoxPost.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkWeatherButton_Click(object sender, EventArgs e)
        {
            FormWeatherCheck weatherCheck = new FormWeatherCheck();

            weatherCheck.SetEventsList();
            weatherCheck.ShowDialog();
        }

        private void sortedPagesButton_Click(object sender, EventArgs e)
        {
            FormSortedPages sortedPagesWindow = new FormSortedPages();

            sortedPagesWindow.InitSortedPagesWindow();
            sortedPagesWindow.ShowDialog();
        }
    }
}
