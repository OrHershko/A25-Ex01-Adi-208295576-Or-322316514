using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    partial class GuessGameForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox guessTextBox;
        private System.Windows.Forms.Button guessButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label currentPageLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.guessTextBox = new System.Windows.Forms.TextBox();
            this.guessButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameExplainationLabel = new System.Windows.Forms.Label();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guessTextBox
            // 
            this.guessTextBox.Location = new System.Drawing.Point(37, 90);
            this.guessTextBox.Name = "guessTextBox";
            this.guessTextBox.Size = new System.Drawing.Size(200, 20);
            this.guessTextBox.TabIndex = 0;
            // 
            // guessButton
            // 
            this.guessButton.Location = new System.Drawing.Point(247, 88);
            this.guessButton.Name = "guessButton";
            this.guessButton.Size = new System.Drawing.Size(75, 23);
            this.guessButton.TabIndex = 1;
            this.guessButton.Text = "Guess";
            this.guessButton.UseVisualStyleBackColor = true;
            this.guessButton.Click += new System.EventHandler(this.guessButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(37, 130);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(155, 13);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.Text = "Make a guess to see the result!";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(37, 160);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(47, 13);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score: 0";
            // 
            // gameExplainationLabel
            // 
            this.gameExplainationLabel.AutoSize = true;
            this.gameExplainationLabel.Location = new System.Drawing.Point(34, 27);
            this.gameExplainationLabel.Name = "gameExplainationLabel";
            this.gameExplainationLabel.Size = new System.Drawing.Size(246, 13);
            this.gameExplainationLabel.TabIndex = 4;
            this.gameExplainationLabel.Text = "Try to guess the exact number of likes of the page!";
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Location = new System.Drawing.Point(34, 61);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(300, 13);
            this.currentPageLabel.TabIndex = 0;
            this.currentPageLabel.Text = "Page Name: [current page]";
            // 
            // GuessGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 204);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.gameExplainationLabel);
            this.Controls.Add(this.guessTextBox);
            this.Controls.Add(this.guessButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.scoreLabel);
            this.Name = "GuessGameForm";
            this.Text = "Guess the Likes Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label gameExplainationLabel;
    }
}
