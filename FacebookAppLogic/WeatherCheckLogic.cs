using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;


namespace FacebookAppLogic
{
    public class WeatherCheckLogic
    {
        public async Task<string> FetchWeatherDataAsync(string i_Location)
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

        public string GenerateWeatherHtml(string i_WeatherDataJson, DateTime i_RequestedDate)
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

    }
}
