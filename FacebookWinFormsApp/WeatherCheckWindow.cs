using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class WeatherCheckWindow : Form
    {
        public WeatherCheckWindow()
        {
            InitializeComponent();
            eventsListBox.SelectedIndexChanged += eventsListBox_SelectedIndexChanged;
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

            FacebookEventWrapper FacebookEventWrapper = new FacebookEventWrapper("Test", new DateTime(2024, 12, 3), "תל אביב");
            eventsListBox.Items.Add(FacebookEventWrapper);
        }

        private void eventsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventsListBox.SelectedItem is FacebookEventWrapper selectedEvent)
            {
                if (!string.IsNullOrEmpty(selectedEvent.Location) && selectedEvent.Date.HasValue)
                {
                    displayWeatherForEvent(selectedEvent.Location, selectedEvent.Date.Value);
                    displayMapOfArea();
                }
                else
                {
                    MessageBox.Show("לאירוע הנבחר חסר מידע על מיקום או תאריך.");
                }
            }
        }


        private async Task<string> fetchWeatherDataAsync(string i_Location, DateTime i_EventDate)
        {
            string apiKey = "yHcai79Hfe5D0B2klSra7g4EfioSH5kn";
            string city = Uri.EscapeDataString(i_Location);
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                                                     new Uri(
                                                         $"https://api.tomorrow.io/v4/weather/forecast?location={city}&timesteps=1d&apikey={apiKey}"),
                Headers = { { "accept", "application/json" } }
            };
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        private string generateWeatherHtml(string i_WeatherDataJson, DateTime i_RequestedDate)
        {
            JsonDocument document = JsonDocument.Parse(i_WeatherDataJson);
            JsonElement root = document.RootElement;

            string cityName = root.GetProperty("location").GetProperty("name").GetString();
            JsonElement dailyData = root.GetProperty("timelines").GetProperty("daily");

            JsonElement? dayElement = dailyData.EnumerateArray().FirstOrDefault(
                d => DateTime.Parse(d.GetProperty("time").GetString()).Date == i_RequestedDate.Date);

            JsonElement dayData = dayElement.Value;

            string date = DateTime.Parse(dayData.GetProperty("time").GetString()).ToShortDateString();
            double temperature = dayData.GetProperty("values").GetProperty("temperatureAvg").GetDouble();
            double humidity = dayData.GetProperty("values").GetProperty("humidityAvg").GetDouble();
            double precipitationProbability =
                dayData.GetProperty("values").GetProperty("precipitationProbabilityAvg").GetDouble();

            return buildHTML(date, cityName, temperature, humidity, precipitationProbability);
        }

        private string buildHTML(
            string i_Date,
            string i_City,
            double i_Temperature,
            double i_Humidity,
            double i_PrecipitationProbability)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.AppendLine("<!DOCTYPE html>").AppendLine("<html>").AppendLine("<head>")
                .AppendLine("    <title>Weather Report</title>").AppendLine("    <style>")
                .AppendLine("        body { font-family: Arial, sans-serif; margin: 10px; }")
                .AppendLine("        h1 { color: #333; }").AppendLine("        h2 { color: #555; }")
                .AppendLine("        p { color: #666; line-height: 0.8; }")
                .AppendLine(
                    "        .weather-container { border: 1px solid #ddd; padding: 15px; border-radius: 5px; max-width: 400px; }")
                .AppendLine("    </style>").AppendLine("</head>").AppendLine("<body>")
                .AppendLine($"    <h1>Weather Report for {i_City}</h1>")
                .AppendLine("    <div class='weather-container'>").AppendLine($"        <h2>Date: {i_Date}</h2>")
                .AppendLine($"        <p><strong>Average Temperature:</strong> {i_Temperature} °C</p>")
                .AppendLine($"        <p><strong>Average Humidity:</strong> {i_Humidity} %</p>")
                .AppendLine(
                    $"        <p><strong>Precipitation Probability:</strong> {i_PrecipitationProbability} %</p>")
                .AppendLine("    </div>").AppendLine("</body>").AppendLine("</html>");

            return htmlBuilder.ToString();
        }


        public async void displayWeatherForEvent(string i_Location, DateTime i_EventDate)
        {
            try
            {
                string weatherDataJson = await fetchWeatherDataAsync(i_Location, i_EventDate);
                string weatherHtml = generateWeatherHtml(weatherDataJson, i_EventDate);
                webBrowser1.DocumentText = weatherHtml;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void displayMapOfArea()
        {
            string cityName = "תל אביב";
            string url = $"https://www.openstreetmap.org/search?query={Uri.EscapeDataString(cityName)}";
            webBrowser1.Navigate(url);
        }
    }
}