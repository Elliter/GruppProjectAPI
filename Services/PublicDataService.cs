using GruppProjectAPI.Models;
using System;
using System.Text.Json;

namespace GruppProjectAPI.Services
{
    public class PublicDataService : IPublicDataService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey = "5db5bd07df87e968ef6b4a6a5c640089";

        public PublicDataService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

         
                var json = await _client.GetStringAsync(url);
            var doc = JsonDocument.Parse(json);

            return new CurrentWeather
            {
                City = city,
                Temperature = doc.RootElement.GetProperty("main").GetProperty("temp").GetSingle(),
                Humidity = doc.RootElement.GetProperty("main").GetProperty("humidity").GetSingle()
            };
            
        }

        public async Task<ForecastWeather> GetForecastAsync(string city)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric";

            var json = await _client.GetStringAsync(url);

            var doc = JsonDocument.Parse(json);
            var list = doc.RootElement.GetProperty("list");

            var temps = new List<float>();
            foreach (var entry in list.EnumerateArray())
            {
                temps.Add(entry.GetProperty("main").GetProperty("temp").GetSingle());
            }

            return new ForecastWeather
            {
                City = city,
                DailyTemperatures = temps
            };
        }
    }

}
