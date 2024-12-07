namespace BasicFacebookFeatures
{
    partial class formSortedPages
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
            this.listBoxSortedPages = new System.Windows.Forms.ListBox();
            this.labelLikedPagesSorted = new System.Windows.Forms.Label();
            this.labelTotalPages = new System.Windows.Forms.Label();
            this.labelmosLLikedPage = new System.Windows.Forms.Label();
            this.labelAverageLikes = new System.Windows.Forms.Label();
            this.chartLikes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonPlayGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartLikes)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxSortedPages
            // 
            this.listBoxSortedPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxSortedPages.FormattingEnabled = true;
            this.listBoxSortedPages.ItemHeight = 50;
            this.listBoxSortedPages.Location = new System.Drawing.Point(15, 70);
            this.listBoxSortedPages.Name = "listBoxSortedPages";
            this.listBoxSortedPages.Size = new System.Drawing.Size(266, 304);
            this.listBoxSortedPages.TabIndex = 0;
            // 
            // labelLikedPagesSorted
            // 
            this.labelLikedPagesSorted.AutoSize = true;
            this.labelLikedPagesSorted.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLikedPagesSorted.Location = new System.Drawing.Point(12, 37);
            this.labelLikedPagesSorted.Name = "labelLikedPagesSorted";
            this.labelLikedPagesSorted.Size = new System.Drawing.Size(362, 16);
            this.labelLikedPagesSorted.TabIndex = 1;
            this.labelLikedPagesSorted.Text = "Liked Pages Sorted From Most to Least Popular";
            // 
            // labelTotalPages
            // 
            this.labelTotalPages.AutoSize = true;
            this.labelTotalPages.Location = new System.Drawing.Point(316, 81);
            this.labelTotalPages.Name = "labelTotalPages";
            this.labelTotalPages.Size = new System.Drawing.Size(69, 13);
            this.labelTotalPages.TabIndex = 2;
            this.labelTotalPages.Text = "Total pages: ";
            // 
            // labelmosLLikedPage
            // 
            this.labelmosLLikedPage.AutoSize = true;
            this.labelmosLLikedPage.Location = new System.Drawing.Point(316, 124);
            this.labelmosLLikedPage.Name = "labelmosLLikedPage";
            this.labelmosLLikedPage.Size = new System.Drawing.Size(93, 13);
            this.labelmosLLikedPage.TabIndex = 3;
            this.labelmosLLikedPage.Text = "Most Liked Page: ";
            // 
            // labelAverageLikes
            // 
            this.labelAverageLikes.AutoSize = true;
            this.labelAverageLikes.Location = new System.Drawing.Point(316, 168);
            this.labelAverageLikes.Name = "labelAverageLikes";
            this.labelAverageLikes.Size = new System.Drawing.Size(81, 13);
            this.labelAverageLikes.TabIndex = 4;
            this.labelAverageLikes.Text = "Avarage Likes: ";
            // 
            // chartLikes
            // 
            this.chartLikes.Location = new System.Drawing.Point(319, 205);
            this.chartLikes.Name = "chartLikes";
            this.chartLikes.Size = new System.Drawing.Size(308, 176);
            this.chartLikes.TabIndex = 5;
            // 
            // buttonPlayGame
            // 
            this.buttonPlayGame.Location = new System.Drawing.Point(48, 392);
            this.buttonPlayGame.Name = "buttonPlayGame";
            this.buttonPlayGame.Size = new System.Drawing.Size(196, 37);
            this.buttonPlayGame.TabIndex = 6;
            this.buttonPlayGame.Text = "Play The Guessing Game!";
            this.buttonPlayGame.UseVisualStyleBackColor = true;
            this.buttonPlayGame.Click += new System.EventHandler(this.playGameButton_Click);
            // 
            // formSortedPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.buttonPlayGame);
            this.Controls.Add(this.chartLikes);
            this.Controls.Add(this.labelAverageLikes);
            this.Controls.Add(this.labelmosLLikedPage);
            this.Controls.Add(this.labelTotalPages);
            this.Controls.Add(this.labelLikedPagesSorted);
            this.Controls.Add(this.listBoxSortedPages);
            this.Name = "formSortedPages";
            this.Text = "Sorted Pages";
            ((System.ComponentModel.ISupportInitialize)(this.chartLikes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSortedPages;
        private System.Windows.Forms.Label labelLikedPagesSorted;
        private System.Windows.Forms.Label labelTotalPages;
        private System.Windows.Forms.Label labelmosLLikedPage;
        private System.Windows.Forms.Label labelAverageLikes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLikes;
        private System.Windows.Forms.Button buttonPlayGame;
    }
}