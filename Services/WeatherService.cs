using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GruppProjectAPI.Moduler;

namespace GruppProjectAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "YOUR_API_KEY_HERE"; // Lägg in din egen API-nyckel

        public WeatherService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var url = $"http://api.weatherstack.com/current?access_key={_apiKey}&query={Uri.EscapeDataString(city)}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<WeatherResponse>(json, options);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to deserialize weather response.");
            }

            return result;
        }
    }
}
