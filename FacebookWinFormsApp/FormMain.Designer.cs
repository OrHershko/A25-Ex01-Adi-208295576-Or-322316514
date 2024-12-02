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
            this.checkWeatherButton = new System.Windows.Forms.Button();
            this.postStatusButton = new System.Windows.Forms.Button();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.albumsLabel = new System.Windows.Forms.Label();
            this.likedPagesLabel = new System.Windows.Forms.Label();
            this.friendsLabel = new System.Windows.Forms.Label();
            this.likedPagesListBox = new System.Windows.Forms.ListBox();
            this.albumsListBox = new System.Windows.Forms.ListBox();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelFeed = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.checkWeatherButton);
            this.tabPage1.Controls.Add(this.postStatusButton);
            this.tabPage1.Controls.Add(this.postTextBox);
            this.tabPage1.Controls.Add(this.usernameLabel);
            this.tabPage1.Controls.Add(this.albumsLabel);
            this.tabPage1.Controls.Add(this.likedPagesLabel);
            this.tabPage1.Controls.Add(this.friendsLabel);
            this.tabPage1.Controls.Add(this.likedPagesListBox);
            this.tabPage1.Controls.Add(this.albumsListBox);
            this.tabPage1.Controls.Add(this.friendsListBox);
            this.tabPage1.Controls.Add(this.flowLayoutPanelFeed);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.label1);
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
            // checkWeatherButton
            // 
            this.checkWeatherButton.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWeatherButton.Location = new System.Drawing.Point(15, 288);
            this.checkWeatherButton.Name = "checkWeatherButton";
            this.checkWeatherButton.Size = new System.Drawing.Size(270, 72);
            this.checkWeatherButton.TabIndex = 66;
            this.checkWeatherButton.Text = "Check Weather Around Upcoming Events ";
            this.checkWeatherButton.UseVisualStyleBackColor = true;
            this.checkWeatherButton.Click += new System.EventHandler(this.checkWeatherButton_Click);
            // 
            // postStatusButton
            // 
            this.postStatusButton.Location = new System.Drawing.Point(712, 116);
            this.postStatusButton.Name = "postStatusButton";
            this.postStatusButton.Size = new System.Drawing.Size(73, 29);
            this.postStatusButton.TabIndex = 65;
            this.postStatusButton.Text = "Post";
            this.postStatusButton.UseVisualStyleBackColor = true;
            this.postStatusButton.Click += new System.EventHandler(this.postStatusButton_Click);
            // 
            // postTextBox
            // 
            this.postTextBox.Location = new System.Drawing.Point(328, 119);
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(374, 24);
            this.postTextBox.TabIndex = 64;
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
            // albumsLabel
            // 
            this.albumsLabel.AutoSize = true;
            this.albumsLabel.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumsLabel.Location = new System.Drawing.Point(831, 378);
            this.albumsLabel.Name = "albumsLabel";
            this.albumsLabel.Size = new System.Drawing.Size(76, 19);
            this.albumsLabel.TabIndex = 62;
            this.albumsLabel.Text = "Albums";
            this.albumsLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // likedPagesLabel
            // 
            this.likedPagesLabel.AutoSize = true;
            this.likedPagesLabel.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.likedPagesLabel.Location = new System.Drawing.Point(831, 127);
            this.likedPagesLabel.Name = "likedPagesLabel";
            this.likedPagesLabel.Size = new System.Drawing.Size(118, 19);
            this.likedPagesLabel.TabIndex = 61;
            this.likedPagesLabel.Text = "Liked Pages";
            this.likedPagesLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // friendsLabel
            // 
            this.friendsLabel.AutoSize = true;
            this.friendsLabel.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendsLabel.Location = new System.Drawing.Point(15, 378);
            this.friendsLabel.Name = "friendsLabel";
            this.friendsLabel.Size = new System.Drawing.Size(74, 19);
            this.friendsLabel.TabIndex = 60;
            this.friendsLabel.Text = "Friends";
            // 
            // likedPagesListBox
            // 
            this.likedPagesListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.likedPagesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.likedPagesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.likedPagesListBox.FormattingEnabled = true;
            this.likedPagesListBox.ItemHeight = 50;
            this.likedPagesListBox.Location = new System.Drawing.Point(835, 149);
            this.likedPagesListBox.Name = "likedPagesListBox";
            this.likedPagesListBox.Size = new System.Drawing.Size(287, 200);
            this.likedPagesListBox.TabIndex = 59;
            // 
            // albumsListBox
            // 
            this.albumsListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.albumsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.albumsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.albumsListBox.FormattingEnabled = true;
            this.albumsListBox.ItemHeight = 50;
            this.albumsListBox.Location = new System.Drawing.Point(835, 402);
            this.albumsListBox.Name = "albumsListBox";
            this.albumsListBox.Size = new System.Drawing.Size(288, 200);
            this.albumsListBox.TabIndex = 58;
            // 
            // friendsListBox
            // 
            this.friendsListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.friendsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.ItemHeight = 50;
            this.friendsListBox.Location = new System.Drawing.Point(19, 400);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(267, 200);
            this.friendsListBox.TabIndex = 57;
            this.friendsListBox.SelectedIndexChanged += new System.EventHandler(this.friendsListBox_SelectedIndexChanged);
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
            this.textBoxAppID.Location = new System.Drawing.Point(317, 61);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 24);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1450160541956417";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 36);
            this.label1.TabIndex = 53;
            this.label1.Text = "This is the AppID of \"Design Patterns App 2.4\". The grader will use it to test yo" +
    "ur app.\r\nType here your own AppID to test it:";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(18, 57);
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
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
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
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label albumsLabel;
        private System.Windows.Forms.Label likedPagesLabel;
        private System.Windows.Forms.Label friendsLabel;
        private System.Windows.Forms.ListBox likedPagesListBox;
        private System.Windows.Forms.ListBox albumsListBox;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFeed;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button postStatusButton;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.Button checkWeatherButton;
    }
}

