using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;
using FacebookAppLogic;

namespace BasicFacebookFeatures
{
    public partial class FormWeatherCheck : Form
    {
        private readonly WeatherCheckLogic m_WeatherCheckLogic = new WeatherCheckLogic();
        public FormWeatherCheck()
        {
            InitializeComponent();
        }

        public void SetEventsList(FacebookObjectCollection<Event> i_FacebookEvents)
        {
            if (i_FacebookEvents == null)
            {
                foreach (Event facebookEvent in i_FacebookEvents)
                {
                    if (facebookEvent.StartTime.HasValue)
                        if (facebookEvent.StartTime.Value.Date < DateTime.Now.AddDays(5) && facebookEvent.StartTime.Value.Date > DateTime.Now)
                        {
                            FacebookEventWrapper facebookEventWrapper = new FacebookEventWrapper(
                                facebookEvent.Name,
                                facebookEvent.StartTime,
                                facebookEvent.Location);
                            listBoxEvents.Items.Add(facebookEventWrapper);
                        }
                }
            }

            //listBoxEvents.Items.Add(new FacebookEventWrapper("avi", DateTime.Now, "תל אביב") );
        }

        private async void displayWeatherForEvent(string i_Location, DateTime i_EventDate)
        {
            try
            {
                string weatherDataJson = await m_WeatherCheckLogic.FetchWeatherDataAsync(i_Location);
                string weatherHtml = m_WeatherCheckLogic.GenerateWeatherHtml(weatherDataJson, i_EventDate);
                webBrowserWeather.DocumentText = weatherHtml;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is FacebookEventWrapper selectedEvent)
            {
                if (!string.IsNullOrEmpty(selectedEvent.Location) && selectedEvent.Date.HasValue)
                {
                    displayWeatherForEvent(selectedEvent.Location, selectedEvent.Date.Value);
                }
                else
                {
                    MessageBox.Show("The selected event is missing information about time and date.");
                }
            }
        }
    }
}