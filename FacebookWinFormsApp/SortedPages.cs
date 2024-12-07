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
    public partial class SortedPages : Form
    {
        private List<Page> m_SortedPages;

        public SortedPages()
        {
            InitializeComponent();
            sortedPagesListBox.DrawItem += FormMain.ListBox_DrawItem;
        }


        public void InitSortedPagesWindow(List<Page> i_SortedLikedPages)
        {
            m_SortedPages = i_SortedLikedPages;
            sortedPagesListBox.Items.Clear();

            foreach (var page in i_SortedLikedPages)
            {
                sortedPagesListBox.Items.Add(new ListBoxItem(page.Name, page.PictureSmallURL));
            }

            int totalPages = i_SortedLikedPages.Count;
            string mostLikedPage = i_SortedLikedPages.OrderByDescending(p => p.LikesCount).FirstOrDefault()?.Name ?? "None";
            double averageLikes = i_SortedLikedPages.Average(p => p.LikesCount).HasValue ? i_SortedLikedPages.Average(p => p.LikesCount).Value : 0;

            totalPagesLabel.Text = $"Total Pages: {totalPages}";
            mostLikedPageLabel.Text = $"Most Liked Page: {mostLikedPage}";
            averageLikesLabel.Text = $"Average Likes: {averageLikes:F2}";

            updateLikesChart(i_SortedLikedPages);
        }

        private void updateLikesChart(List<Page> i_SortedLikedPages)
        {
            likesChart.Series.Clear();
            likesChart.ChartAreas.Clear();

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            likesChart.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
                             {
                                 Name = "Likes",
                                 ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
                             };

            foreach (var page in i_SortedLikedPages)
            {
                series.Points.AddXY(page.Name, page.LikesCount);
            }

            likesChart.Series.Add(series);
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            if (m_SortedPages == null || m_SortedPages.Count == 0)
            {
                MessageBox.Show("No pages available to play the game!", "No Pages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuessGameForm gameForm = new GuessGameForm(m_SortedPages);
            gameForm.ShowDialog();
        }

    }
}
