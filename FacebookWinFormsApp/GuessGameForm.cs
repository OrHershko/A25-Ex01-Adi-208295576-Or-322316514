﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class GuessGameForm : Form
    {
        private List<Page> m_Pages;
        private int m_CurrentIndex = 0;
        private int m_Score = 0;

        public GuessGameForm(List<Page> i_Pages)
        {
            InitializeComponent();
            m_Pages = i_Pages;
            m_CurrentIndex = 0;
            m_Score = 0;
            displayNextPage();
        }


        private void displayNextPage()
        {
            if (m_CurrentIndex < m_Pages.Count)
            {
                var currentPage = m_Pages[m_CurrentIndex];
                currentPageLabel.Text = $"Page Name: {currentPage.Name}";
            }
            else
            {
                MessageBox.Show($"Game Over! Your final score: {m_Score}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        private void guessButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(guessTextBox.Text, out int userGuess))
            {
                resultLabel.Text = "Please enter a valid number.";
                resultLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            var currentPage = m_Pages[m_CurrentIndex];
            long actualLikes = currentPage.LikesCount ?? 0;

            int difference = Math.Abs(userGuess - (int)actualLikes);

            if (difference == 0)
            {
                m_Score += 10;
                resultLabel.Text = $"Spot on! The page has exactly {actualLikes} likes!";
                resultLabel.ForeColor = System.Drawing.Color.Green;
            }
            else if (difference <= 100)
            {
                m_Score += 5;
                resultLabel.Text = $"Close enough! The page has {actualLikes} likes.";
                resultLabel.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                m_Score -= 1;
                resultLabel.Text = $"Not quite. The page has {actualLikes} likes.";
                resultLabel.ForeColor = System.Drawing.Color.Red;
            }

            scoreLabel.Text = $"Score: {m_Score}";
            m_CurrentIndex++;
            displayNextPage();
        }
        
    }
}