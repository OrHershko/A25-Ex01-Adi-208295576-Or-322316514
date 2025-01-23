using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookAppLogic;
using FacebookWrapper.ObjectModel;
using static FacebookAppLogic.GuessGameLogic;

namespace BasicFacebookFeatures
{
    public partial class FormGuessGame : Form
    {
        private readonly GuessGameLogic r_GuessGameLogic;

        public FormGuessGame(List<Page> i_Pages)
        {
            InitializeComponent();
            r_GuessGameLogic = new GuessGameLogic(i_Pages);
            displayNextPage();
        }

        private void displayNextPage()
        {
            if(r_GuessGameLogic.IsThereMorePages())
            {
                labelCurrentPage.Text = $"Page Name: {r_GuessGameLogic.GetCurrentPage().Name}";
            }
            else
            {
                MessageBox.Show(
                    $"Game Over! Your final score: {r_GuessGameLogic.Score}",
                    "Game Over",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textBoxGuess.Text, out int userGuess))
            {
                LabelResult.Text = "Please enter a valid number.";
                LabelResult.ForeColor = System.Drawing.Color.Red;
                return;
            }

            long actualLikes = r_GuessGameLogic.GetCurrentPage().LikesCount ?? 0;
            eAnswerStatus answerStatus = r_GuessGameLogic.CheckPlayerGuess(userGuess);

            switch(answerStatus)
            {
                case eAnswerStatus.Correct:
                    LabelResult.Text = $"Spot on! The page has exactly {actualLikes} likes!";
                    LabelResult.ForeColor = System.Drawing.Color.Green;
                    break;

                case eAnswerStatus.Almost:
                    LabelResult.Text = $"Close enough! The page has {actualLikes} likes.";
                    LabelResult.ForeColor = System.Drawing.Color.Orange;
                    break;

                case eAnswerStatus.Wrong:
                    LabelResult.Text = $"Not quite. The page has {actualLikes} likes.";
                    LabelResult.ForeColor = System.Drawing.Color.Red;
                    break;
            }

            LabelScore.Text = $"Score: {r_GuessGameLogic.Score}";
            displayNextPage();
        }
    }
}