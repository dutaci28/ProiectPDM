using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDM.Services
{
    public class VremeService
    {
        private const string ApiKey = "8353c7c295fa4a81951a880095f94183";
        private const string ApiBaseUrl = "https://api.openweathermap.org/data/2.5/forecast";

        public async Task<List<WeatherData>> GetWeatherDataAsync(string city)
        {
            using (var httpClient = new HttpClient())
            {
                var apiUrl = $"{ApiBaseUrl}?q={city}&appid={ApiKey}&units=metric";
                var response = await httpClient.GetStringAsync(apiUrl);

                var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(response);

                return weatherData?.list;
            }
        }

    }

    public class WeatherData
    {
        public long dt { get; set; }
        public Main main { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
    }

    public class WeatherResponse
    {
        public List<WeatherData> list { get; set; }
    }
}
