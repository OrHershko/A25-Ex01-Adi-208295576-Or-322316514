using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class WeatherReportComposer
    {
        private readonly WeatherCheckLogic m_WeatherCheckLogic;

        public WeatherReportComposer()
        {
            m_WeatherCheckLogic = new WeatherCheckLogic();
        }

        public async Task<string> CreateWeatherReportAsync(string i_Location, DateTime i_Date)
        {
            string weatherDataJson = await m_WeatherCheckLogic.FetchWeatherDataAsync(i_Location);

            JsonDocument document = JsonDocument.Parse(weatherDataJson);
            JsonElement root = document.RootElement;
            string cityName = root.GetProperty("location").GetProperty("name").GetString();

            JsonElement dailyData = root.GetProperty("timelines").GetProperty("daily");
            JsonElement? dayElement = dailyData.EnumerateArray().FirstOrDefault(
                d => DateTime.Parse(d.GetProperty("time").GetString()).Date == i_Date.Date);

            if (dayElement.HasValue)
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
