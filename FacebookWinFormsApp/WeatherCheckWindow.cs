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

        public void SetEventsList()
        {
            FacebookObjectCollection<Event> facebookEvents = LoggedInUserSingleton.Instance.LoginResult.LoggedInUser.Events;

            if (facebookEvents == null)
            {
                foreach (Event facebookEvent in facebookEvents)
                {
                    if (facebookEvent.StartTime.HasValue)
                        if (facebookEvent.StartTime.Value.Date < DateTime.Now.AddDays(5) && facebookEvent.StartTime.Value.Date > DateTime.Now)
                        {
                            EventProxy eventProxy = new EventProxy(facebookEvent);
                            listBoxEvents.Items.Add(eventProxy);
                        }
                }
            }
        }

        private async void displayWeatherForEvent(string i_Location, DateTime i_EventDate)
        {
            try
            {
                WeatherReportComposer composer = new WeatherReportComposer();
                string weatherReportHtml = await composer.CreateWeatherReportAsync(i_Location, i_EventDate);
                webBrowserWeather.DocumentText = weatherReportHtml;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch weather report: {ex.Message}");
            }
        }


        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem is EventProxy selectedEvent)
            {
                if (!string.IsNullOrEmpty(selectedEvent.Event.Location) && selectedEvent.Event.StartTime.HasValue)
                {
                    displayWeatherForEvent(selectedEvent.Event.Location, selectedEvent.Event.StartTime.Value);
                }
                else
                {
                    MessageBox.Show("The selected event is missing information about time and date.");
                }
            }
        }
    }
}