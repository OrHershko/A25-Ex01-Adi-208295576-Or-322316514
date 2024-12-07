namespace BasicFacebookFeatures
{
    partial class SortedPages
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
            this.sortedPagesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.mostLikedPageLabel = new System.Windows.Forms.Label();
            this.averageLikesLabel = new System.Windows.Forms.Label();
            this.likesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.playGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.likesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // sortedPagesListBox
            // 
            this.sortedPagesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sortedPagesListBox.FormattingEnabled = true;
            this.sortedPagesListBox.ItemHeight = 50;
            this.sortedPagesListBox.Location = new System.Drawing.Point(15, 70);
            this.sortedPagesListBox.Name = "sortedPagesListBox";
            this.sortedPagesListBox.Size = new System.Drawing.Size(266, 304);
            this.sortedPagesListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liked Pages Sorted From Most to Least Popular";
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Location = new System.Drawing.Point(316, 81);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(69, 13);
            this.totalPagesLabel.TabIndex = 2;
            this.totalPagesLabel.Text = "Total pages: ";
            // 
            // mostLikedPageLabel
            // 
            this.mostLikedPageLabel.AutoSize = true;
            this.mostLikedPageLabel.Location = new System.Drawing.Point(316, 124);
            this.mostLikedPageLabel.Name = "mostLikedPageLabel";
            this.mostLikedPageLabel.Size = new System.Drawing.Size(93, 13);
            this.mostLikedPageLabel.TabIndex = 3;
            this.mostLikedPageLabel.Text = "Most Liked Page: ";
            // 
            // averageLikesLabel
            // 
            this.averageLikesLabel.AutoSize = true;
            this.averageLikesLabel.Location = new System.Drawing.Point(316, 168);
            this.averageLikesLabel.Name = "averageLikesLabel";
            this.averageLikesLabel.Size = new System.Drawing.Size(81, 13);
            this.averageLikesLabel.TabIndex = 4;
            this.averageLikesLabel.Text = "Avarage Likes: ";
            // 
            // likesChart
            // 
            this.likesChart.Location = new System.Drawing.Point(319, 205);
            this.likesChart.Name = "likesChart";
            this.likesChart.Size = new System.Drawing.Size(308, 176);
            this.likesChart.TabIndex = 5;
            // 
            // playGameButton
            // 
            this.playGameButton.Location = new System.Drawing.Point(48, 392);
            this.playGameButton.Name = "playGameButton";
            this.playGameButton.Size = new System.Drawing.Size(196, 37);
            this.playGameButton.TabIndex = 6;
            this.playGameButton.Text = "Play The Guessing Game!";
            this.playGameButton.UseVisualStyleBackColor = true;
            this.playGameButton.Click += new System.EventHandler(this.playGameButton_Click);
            // 
            // SortedPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.playGameButton);
            this.Controls.Add(this.likesChart);
            this.Controls.Add(this.averageLikesLabel);
            this.Controls.Add(this.mostLikedPageLabel);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sortedPagesListBox);
            this.Name = "SortedPages";
            this.Text = "SortedPages";
            ((System.ComponentModel.ISupportInitialize)(this.likesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sortedPagesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Label mostLikedPageLabel;
        private System.Windows.Forms.Label averageLikesLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart likesChart;
        private System.Windows.Forms.Button playGameButton;
    }
}