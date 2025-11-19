using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace WeatherAPIRazor.Data
{
    public class WeatherService
    {
        private readonly HttpClient _http;

        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city, string apiKey)
        {
            string url = //$"https://api.openweathermap.org/data/2.5/weather?q=m%C3%A4rsta&appid=5db5bd07df87e968ef6b4a6a5c640089&units=metric";
              $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<WeatherResponse>(stream);

            return result;
        }
    }

    // Model mapping JSON
    public class WeatherResponse
    {
        public Main? main { get; set; }
        public string? name { get; set; }
        public Weather[]? weather { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float humidity { get; set; }
    }

    public class Weather
    {
        public string? description { get; set; }
    }
}
