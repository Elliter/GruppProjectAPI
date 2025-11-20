using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GruppProjectAPI.Models;

namespace GruppProjectAPI.Services
{
    public class WeatherServiceAPI
    {
        private readonly HttpClient _http;
        private const double Latitude = 57.72;
        private const double Longitude = 12.94;
        private readonly string _location;

        public WeatherServiceAPI(HttpClient http, IConfiguration config)
        {
            _http = http;
            _location = config.GetValue<string>("WeatherStack:Location") ?? "Boras";
        }

        public async Task<WeatherDayAPI?> GetWeeklyFromOpenMeteoAsync()
        {
            var end = DateTime.UtcNow.Date;
            var start = end.AddDays(-6);
            string s = start.ToString("yyyy-MM-dd");
            string e = end.ToString("yyyy-MM-dd");

            var url = $"https://archive-api.open-meteo.com/v1/archive?latitude={Latitude}&longitude={Longitude}&start_date={s}&end_date={e}&hourly=temperature_2m,precipitation&timezone=Europe%2FStockholm";

            try
            {
                var res = await _http.GetAsync(url);
                res.EnsureSuccessStatusCode();
                var json = await res.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<OpenMeteoAPI>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (data?.Hourly?.Temperature2m == null) return null;

                double avgTemp = data.Hourly.Temperature2m.Average();
                double totalPrec = data.Hourly.Precipitation?.Sum() ?? 0;
                int days = (end - start).Days + 1;
                double avgDaily = totalPrec / days;

                return new WeatherDayAPI
                {
                    Temperature = Math.Round(avgTemp, 2),
                    Precipitation = Math.Round(avgDaily, 2)
                };
            }
            catch { return null; }
        }

        public Task<WeatherDayAPI?> GetWeatherForDate(string d) => GetWeeklyFromOpenMeteoAsync();
    }
}
