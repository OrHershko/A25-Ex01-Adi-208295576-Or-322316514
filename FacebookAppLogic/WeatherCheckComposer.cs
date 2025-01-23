using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class WeatherReportComposer
    {
        private readonly WeatherCheckLogic r_WeatherCheckLogic = new WeatherCheckLogic();

        public async Task<string> CreateWeatherReportAsync(string i_Location, DateTime i_Date)
        {
            string weatherDataJson = await r_WeatherCheckLogic.FetchWeatherDataAsync(i_Location);
            JsonDocument document = JsonDocument.Parse(weatherDataJson);
            JsonElement root = document.RootElement;
            string cityName = root.GetProperty("location").GetProperty("name").GetString();
            JsonElement dailyData = root.GetProperty("timelines").GetProperty("daily");
            JsonElement? dayElement = dailyData.EnumerateArray().FirstOrDefault(
                i_JsonElement => DateTime.Parse(i_JsonElement.GetProperty("time").GetString()).Date == i_Date.Date);

            if (dayElement.Value.ValueKind != JsonValueKind.Undefined)
            {
                JsonElement dayData = dayElement.Value;
                string date = DateTime.Parse(dayData.GetProperty("time").GetString()).ToShortDateString();
                double temperature = dayData.GetProperty("values").GetProperty("temperatureAvg").GetDouble();
                double humidity = dayData.GetProperty("values").GetProperty("humidityAvg").GetDouble();
                double precipitation =
                    dayData.GetProperty("values").GetProperty("precipitationProbabilityAvg").GetDouble();

                WeatherReportBuilder builder = new WeatherReportBuilder();
                return builder.SetDate(date)
                    .SetCity(cityName)
                    .SetTemperature(temperature)
                    .SetHumidity(humidity)
                    .SetPrecipitation(precipitation)
                    .Build();
            }
            else
            {
                throw new Exception("No weather data available for the requested date.");
            }
        }
    }
}
