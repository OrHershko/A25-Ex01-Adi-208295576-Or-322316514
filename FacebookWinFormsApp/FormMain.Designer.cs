using System.Drawing;

namespace BasicFacebookFeatures
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxFacebookLogo = new System.Windows.Forms.PictureBox();
            this.buttonSortPage = new System.Windows.Forms.Button();
            this.buttonCheckWeather = new System.Windows.Forms.Button();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.labelAlbums = new System.Windows.Forms.Label();
            this.labelLikedPages = new System.Windows.Forms.Label();
            this.labelFriends = new System.Windows.Forms.Label();
            this.listBoxLikedPages = new System.Windows.Forms.ListBox();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelFeed = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.labelAppId = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebookLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1235, 666);
            this.tabPage2.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxFacebookLogo);
            this.tabPage1.Controls.Add(this.buttonSortPage);
            this.tabPage1.Controls.Add(this.buttonCheckWeather);
            this.tabPage1.Controls.Add(this.buttonPostStatus);
            this.tabPage1.Controls.Add(this.textBoxPost);
            this.tabPage1.Controls.Add(this.usernameLabel);
            this.tabPage1.Controls.Add(this.labelAlbums);
            this.tabPage1.Controls.Add(this.labelLikedPages);
            this.tabPage1.Controls.Add(this.labelFriends);
            this.tabPage1.Controls.Add(this.listBoxLikedPages);
            this.tabPage1.Controls.Add(this.listBoxAlbums);
            this.tabPage1.Controls.Add(this.listBoxFriends);
            this.tabPage1.Controls.Add(this.flowLayoutPanelFeed);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.labelAppId);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1235, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home Page";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxFacebookLogo
            // 
            this.pictureBoxFacebookLogo.Image = global::BasicFacebookFeatures.Properties.Resources.facebook_login;
            this.pictureBoxFacebookLogo.Location = new System.Drawing.Point(18, 3);
            this.pictureBoxFacebookLogo.Name = "pictureBoxFacebookLogo";
            this.pictureBoxFacebookLogo.Size = new System.Drawing.Size(235, 87);
            this.pictureBoxFacebookLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFacebookLogo.TabIndex = 68;
            this.pictureBoxFacebookLogo.TabStop = false;
            // 
            // buttonSortPage
            // 
            this.buttonSortPage.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSortPage.Location = new System.Drawing.Point(15, 198);
            this.buttonSortPage.Name = "buttonSortPage";
            this.buttonSortPage.Size = new System.Drawing.Size(270, 71);
            this.buttonSortPage.TabIndex = 67;
            this.buttonSortPage.Text = "Sort Liked Pages By Popularity And Play The Guessing Game";
            this.buttonSortPage.UseVisualStyleBackColor = true;
            this.buttonSortPage.Click += new System.EventHandler(this.sortedPagesButton_Click);
            // 
            // buttonCheckWeather
            // 
            this.buttonCheckWeather.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckWeather.Location = new System.Drawing.Point(15, 288);
            this.buttonCheckWeather.Name = "buttonCheckWeather";
            this.buttonCheckWeather.Size = new System.Drawing.Size(270, 72);
            this.buttonCheckWeather.TabIndex = 66;
            this.buttonCheckWeather.Text = "Check Weather Around Upcoming Events On The Next 5 Days";
            this.buttonCheckWeather.UseVisualStyleBackColor = true;
            this.buttonCheckWeather.Click += new System.EventHandler(this.checkWeatherButton_Click);
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Location = new System.Drawing.Point(712, 116);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(73, 29);
            this.buttonPostStatus.TabIndex = 65;
            this.buttonPostStatus.Text = "Post";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            this.buttonPostStatus.Click += new System.EventHandler(this.postStatusButton_Click);
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(328, 119);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(374, 24);
            this.textBoxPost.TabIndex = 64;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(115, 101);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(0, 20);
            this.usernameLabel.TabIndex = 63;
            // 
            // labelAlbums
            // 
            this.labelAlbums.AutoSize = true;
            this.labelAlbums.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlbums.Location = new System.Drawing.Point(831, 378);
            this.labelAlbums.Name = "labelAlbums";
            this.labelAlbums.Size = new System.Drawing.Size(76, 19);
            this.labelAlbums.TabIndex = 62;
            this.labelAlbums.Text = "Albums";
            // 
            // labelLikedPages
            // 
            this.labelLikedPages.AutoSize = true;
            this.labelLikedPages.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLikedPages.Location = new System.Drawing.Point(831, 127);
            this.labelLikedPages.Name = "labelLikedPages";
            this.labelLikedPages.Size = new System.Drawing.Size(118, 19);
            this.labelLikedPages.TabIndex = 61;
            this.labelLikedPages.Text = "Liked Pages";
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriends.Location = new System.Drawing.Point(15, 378);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(74, 19);
            this.labelFriends.TabIndex = 60;
            this.labelFriends.Text = "Friends";
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxLikedPages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxLikedPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.ItemHeight = 50;
            this.listBoxLikedPages.Location = new System.Drawing.Point(835, 149);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(287, 200);
            this.listBoxLikedPages.TabIndex = 59;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxAlbums.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxAlbums.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 50;
            this.listBoxAlbums.Location = new System.Drawing.Point(835, 402);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(288, 200);
            this.listBoxAlbums.TabIndex = 58;
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxFriends.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFriends.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 50;
            this.listBoxFriends.Location = new System.Drawing.Point(19, 400);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(267, 200);
            this.listBoxFriends.TabIndex = 57;
            // 
            // flowLayoutPanelFeed
            // 
            this.flowLayoutPanelFeed.AutoScroll = true;
            this.flowLayoutPanelFeed.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFeed.Location = new System.Drawing.Point(328, 152);
            this.flowLayoutPanelFeed.Name = "flowLayoutPanelFeed";
            this.flowLayoutPanelFeed.Size = new System.Drawing.Size(458, 454);
            this.flowLayoutPanelFeed.TabIndex = 56;
            this.flowLayoutPanelFeed.WrapContents = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(18, 96);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(79, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(588, 52);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 24);
            this.textBoxAppID.TabIndex = 54;
            // 
            // labelAppId
            // 
            this.labelAppId.AutoSize = true;
            this.labelAppId.Location = new System.Drawing.Point(585, 19);
            this.labelAppId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppId.Name = "labelAppId";
            this.labelAppId.Size = new System.Drawing.Size(55, 18);
            this.labelAppId.TabIndex = 53;
            this.labelAppId.Text = "App ID:";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(299, 52);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(299, 12);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook Winforms App";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebookLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label labelAlbums;
        private System.Windows.Forms.Label labelLikedPages;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.ListBox listBoxLikedPages;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFeed;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.Label labelAppId;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.Button buttonCheckWeather;
        private System.Windows.Forms.Button buttonSortPage;
        private System.Windows.Forms.PictureBox pictureBoxFacebookLogo;
    }
}

