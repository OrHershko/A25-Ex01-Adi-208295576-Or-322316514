using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class WeatherCheckWindow : Form
    {

        public WeatherCheckWindow()
        {
            InitializeComponent();
            this.eventsListBox.SelectedIndexChanged += this.eventsListBox_SelectedIndexChanged;
        }

        public void setEventsList(FacebookObjectCollection<Event> i_FacebookEvents)
        {
            //if(i_FacebookEvents == null)
            //{
            //    foreach(Event facebookEvent in i_FacebookEvents)
            //    {
            //        FacebookEvent FacebookEventWrapper = new FacebookEvent(
            //            facebookEvent.Name,
            //            facebookEvent.StartTime,
            //            facebookEvent.Location);
            //        eventsListBox.Items.Add(FacebookEventWrapper);
            //    }
            //}

            FacebookEvent FacebookEventWrapper = new FacebookEvent(
                        "Test",
                        new DateTime(2024,12,3),
                        "תל אביב");
            eventsListBox.Items.Add(FacebookEventWrapper);
        }

        private void eventsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // בדוק שהמשתמש באמת בחר פריט ולא ביטל בחירה
            if (eventsListBox.SelectedItem is FacebookEvent selectedEvent)
            {
                if (!string.IsNullOrEmpty(selectedEvent.Location) && selectedEvent.Date.HasValue)
                {
                    // קריאה לפונקציה להצגת תחזית מזג האוויר
                    displayWeatherForEvent(selectedEvent.Location, selectedEvent.Date.Value);
                }
                else
                {
                    // טיפול במקרה שבו האירוע חסר מידע נדרש
                    MessageBox.Show("לאירוע הנבחר חסר מידע על מיקום או תאריך.");
                }
            }
        }


        private async Task<string> fetchWeatherDataAsync(string location, DateTime eventDate)
        {
            string apiKey = "yHcai79Hfe5D0B2klSra7g4EfioSH5kn"; // החלף במפתח ה-API שלך
            string city = Uri.EscapeDataString(location);
            var client = new HttpClient();
            var request = new HttpRequestMessage
                              {
                                  Method = HttpMethod.Get,
                                  RequestUri = new Uri($"https://api.tomorrow.io/v4/weather/forecast?location={city}&timesteps=1d&apikey={apiKey}"),
                                  Headers =
                                      {
                                          { "accept", "application/json" },
                                      },
                              };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        private string generateWeatherHtml(string i_WeatherDataJson, DateTime i_RequestedDate)
        {
            var document = JsonDocument.Parse(i_WeatherDataJson);
            var root = document.RootElement;

            string cityName = root.GetProperty("location").GetProperty("name").GetString();
            var dailyData = root.GetProperty("timelines").GetProperty("daily");

            JsonElement? dayElement = dailyData.EnumerateArray()
                .FirstOrDefault(d => DateTime.Parse(d.GetProperty("time").GetString()).Date == i_RequestedDate.Date);

            var dayData = dayElement.Value;

            string date = DateTime.Parse(dayData.GetProperty("time").GetString()).ToShortDateString();
            double temperature = dayData.GetProperty("values").GetProperty("temperatureAvg").GetDouble();
            double humidity = dayData.GetProperty("values").GetProperty("humidityAvg").GetDouble();
            double precipitationProbability = dayData.GetProperty("values").GetProperty("precipitationProbabilityAvg").GetDouble();

            return buildHTML(date, cityName, temperature, humidity, precipitationProbability);
        }

        private string buildHTML(string i_Date, string i_City, double i_Temperature, double i_Humidity, double i_PrecipitationProbability)
        {
            var htmlBuilder = new StringBuilder();

            htmlBuilder
                .AppendLine("<!DOCTYPE html>")
                .AppendLine("<html>")
                .AppendLine("<head>")
                .AppendLine("    <title>Weather Report</title>")
                .AppendLine("    <style>")
                .AppendLine("        body { font-family: Arial, sans-serif; margin: 10px; }")
                .AppendLine("        h1 { color: #333; }")
                .AppendLine("        h2 { color: #555; }")
                .AppendLine("        p { color: #666; line-height: 0.8; }")
                .AppendLine("        .weather-container { border: 1px solid #ddd; padding: 15px; border-radius: 5px; max-width: 400px; }")
                .AppendLine("    </style>")
                .AppendLine("</head>")
                .AppendLine("<body>")
                .AppendLine($"    <h1>Weather Report for {i_City}</h1>")
                .AppendLine("    <div class='weather-container'>")
                .AppendLine($"        <h2>Date: {i_Date}</h2>")
                .AppendLine($"        <p><strong>Average Temperature:</strong> {i_Temperature} °C</p>")
                .AppendLine($"        <p><strong>Average Humidity:</strong> {i_Humidity} %</p>")
                .AppendLine($"        <p><strong>Precipitation Probability:</strong> {i_PrecipitationProbability} %</p>")
                .AppendLine("    </div>")
                .AppendLine("</body>")
                .AppendLine("</html>");

            return htmlBuilder.ToString();
        }


        public async void displayWeatherForEvent(string location, DateTime eventDate)
        {
            try
            {
                string weatherDataJson = await fetchWeatherDataAsync(location, eventDate);
                string weatherHtml = generateWeatherHtml(weatherDataJson, eventDate);
                webBrowser1.DocumentText = weatherHtml;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
