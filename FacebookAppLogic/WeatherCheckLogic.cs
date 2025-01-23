using System;
using System.Net.Http;
using System.Threading.Tasks;

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
                RequestUri =new Uri($"https://api.tomorrow.io/v4/weather/forecast?location={city}&timesteps=1d&apikey={apiKey}"),
                Headers = { { "accept", "application/json" } }
            };

            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
