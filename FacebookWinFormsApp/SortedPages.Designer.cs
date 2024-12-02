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
            this.SuspendLayout();
            // 
            // sortedPagesListBox
            // 
            this.sortedPagesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sortedPagesListBox.FormattingEnabled = true;
            this.sortedPagesListBox.ItemHeight = 50;
            this.sortedPagesListBox.Location = new System.Drawing.Point(33, 77);
            this.sortedPagesListBox.Name = "sortedPagesListBox";
            this.sortedPagesListBox.Size = new System.Drawing.Size(361, 304);
            this.sortedPagesListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liked Pages Sorted From Most to Least Popular";
            // 
            // SortedPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sortedPagesListBox);
            this.Name = "SortedPages";
            this.Text = "SortedPages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sortedPagesListBox;
        private System.Windows.Forms.Label label1;
    }
}