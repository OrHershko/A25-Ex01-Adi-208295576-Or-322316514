using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    partial class FormGuessGame
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Button buttonGuess;
        private System.Windows.Forms.Label LabelResult;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Label labelCurrentPage;

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
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.buttonGuess = new System.Windows.Forms.Button();
            this.LabelResult = new System.Windows.Forms.Label();
            this.LabelScore = new System.Windows.Forms.Label();
            this.labelGameExplaination = new System.Windows.Forms.Label();
            this.labelCurrentPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Location = new System.Drawing.Point(37, 90);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(200, 20);
            this.textBoxGuess.TabIndex = 0;
            // 
            // buttonGuess
            // 
            this.buttonGuess.Location = new System.Drawing.Point(247, 88);
            this.buttonGuess.Name = "buttonGuess";
            this.buttonGuess.Size = new System.Drawing.Size(75, 23);
            this.buttonGuess.TabIndex = 1;
            this.buttonGuess.Text = "Guess";
            this.buttonGuess.UseVisualStyleBackColor = true;
            this.buttonGuess.Click += new System.EventHandler(this.guessButton_Click);
            // 
            // LabelResult
            // 
            this.LabelResult.AutoSize = true;
            this.LabelResult.Location = new System.Drawing.Point(37, 130);
            this.LabelResult.Name = "LabelResult";
            this.LabelResult.Size = new System.Drawing.Size(155, 13);
            this.LabelResult.TabIndex = 2;
            this.LabelResult.Text = "Make a guess to see the result!";
            // 
            // LabelScore
            // 
            this.LabelScore.AutoSize = true;
            this.LabelScore.Location = new System.Drawing.Point(37, 160);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(47, 13);
            this.LabelScore.TabIndex = 3;
            this.LabelScore.Text = "Score: 0";
            // 
            // labelGameExplaination
            // 
            this.labelGameExplaination.AutoSize = true;
            this.labelGameExplaination.Location = new System.Drawing.Point(34, 27);
            this.labelGameExplaination.Name = "labelGameExplaination";
            this.labelGameExplaination.Size = new System.Drawing.Size(246, 13);
            this.labelGameExplaination.TabIndex = 4;
            this.labelGameExplaination.Text = "Try to guess the exact number of likes of the page!";
            // 
            // labelCurrentPage
            // 
            this.labelCurrentPage.Location = new System.Drawing.Point(34, 61);
            this.labelCurrentPage.Name = "labelCurrentPage";
            this.labelCurrentPage.Size = new System.Drawing.Size(300, 13);
            this.labelCurrentPage.TabIndex = 0;
            this.labelCurrentPage.Text = "Page Name: [current page]";
            // 
            // formGuessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 204);
            this.Controls.Add(this.labelCurrentPage);
            this.Controls.Add(this.labelGameExplaination);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.buttonGuess);
            this.Controls.Add(this.LabelResult);
            this.Controls.Add(this.LabelScore);
            this.Name = "FormGuessGame";
            this.Text = "Guess the Likes Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label labelGameExplaination;
    }
}
