using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormSortedPages : Form
    {
        private List<Page> m_SortedPages;

        public FormSortedPages()
        {
            InitializeComponent();
            listBoxSortedPages.DrawItem += FormMain.ListBox_DrawItem;
        }


        public void InitSortedPagesWindow()
        {
            m_SortedPages = LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.LikedPages.OrderBy(page => page.LikesCount).ToList();
            listBoxSortedPages.Items.Clear();

            foreach (var page in m_SortedPages)
            {
                listBoxSortedPages.Items.Add(new ListBoxItem(page.Name, page.PictureSmallURL));
            }

            int totalPages = m_SortedPages.Count;
            string mostLikedPage = m_SortedPages.OrderByDescending(p => p.LikesCount).FirstOrDefault()?.Name ?? "None";
            double averageLikes = m_SortedPages.Average(p => p.LikesCount).HasValue ? m_SortedPages.Average(p => p.LikesCount).Value : 0;

            labelTotalPages.Text = $"Total Pages: {totalPages}";
            labelmosLLikedPage.Text = $"Most Liked Page: {mostLikedPage}";
            labelAverageLikes.Text = $"Average Likes: {averageLikes:F2}";

            updateLikesChart();
        }

        private void updateLikesChart()
        {
            chartLikes.Series.Clear();
            chartLikes.ChartAreas.Clear();

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartLikes.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
                             {
                                 Name = "Likes",
                                 ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
                             };

            foreach (var page in m_SortedPages)
            {
                series.Points.AddXY(page.Name, page.LikesCount);
            }

            chartLikes.Series.Add(series);
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            if (m_SortedPages == null || m_SortedPages.Count == 0)
            {
                MessageBox.Show("No pages available to play the game!", "No Pages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormGuessGame gameForm = new FormGuessGame(m_SortedPages);
            gameForm.ShowDialog();
        }

    }
}
