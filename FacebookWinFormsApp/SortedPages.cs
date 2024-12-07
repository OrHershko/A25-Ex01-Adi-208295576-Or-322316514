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
    public partial class formSortedPages : Form
    {
        private List<Page> m_SortedPages;

        public formSortedPages()
        {
            InitializeComponent();
            listBoxSortedPages.DrawItem += FormMain.ListBox_DrawItem;
        }


        public void InitSortedPagesWindow(List<Page> i_SortedLikedPages)
        {
            m_SortedPages = i_SortedLikedPages;
            listBoxSortedPages.Items.Clear();

            foreach (var page in i_SortedLikedPages)
            {
                listBoxSortedPages.Items.Add(new ListBoxItem(page.Name, page.PictureSmallURL));
            }

            int totalPages = i_SortedLikedPages.Count;
            string mostLikedPage = i_SortedLikedPages.OrderByDescending(p => p.LikesCount).FirstOrDefault()?.Name ?? "None";
            double averageLikes = i_SortedLikedPages.Average(p => p.LikesCount).HasValue ? i_SortedLikedPages.Average(p => p.LikesCount).Value : 0;

            labelTotalPages.Text = $"Total Pages: {totalPages}";
            labelmosLLikedPage.Text = $"Most Liked Page: {mostLikedPage}";
            labelAverageLikes.Text = $"Average Likes: {averageLikes:F2}";

            updateLikesChart(i_SortedLikedPages);
        }

        private void updateLikesChart(List<Page> i_SortedLikedPages)
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

            foreach (var page in i_SortedLikedPages)
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

            formGuessGame gameForm = new formGuessGame(m_SortedPages);
            gameForm.ShowDialog();
        }

    }
}
