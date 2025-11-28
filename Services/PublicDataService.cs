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
                Humidity = doc.RootElement.GetProperty("main").GetProperty("humidity").GetSingle(),
            };
            
        }

        public async Task<ForecastWeather> GetForecastAsync(string city)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric";

            var json = await _client.GetStringAsync(url);

            var doc = JsonDocument.Parse(json);
            var list = doc.RootElement.GetProperty("list");
           
            Dictionary<DateTime, List<float>> dailyGroups = new();
            List<string> days =new();

            foreach (var entry in list.EnumerateArray())
            {
                float temp = entry.GetProperty("main").GetProperty("temp").GetSingle();

                string dtTxt = entry.GetProperty("dt_txt").GetString()!;

                DateTime dt = DateTime.ParseExact(dtTxt,"yyyy-MM-dd HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture);

                DateTime day = dt.Date;

                if (!dailyGroups.ContainsKey(day))
                    dailyGroups[day] = new List<float>();

                dailyGroups[day].Add(temp);
                string dayName = dt.DayOfWeek.ToString();
                if (!days.Contains(dayName))
                    days.Add(dayName);

            }

            List<float> dailyAverages = dailyGroups.Select(g => g.Value.Average()).ToList(); 

            return new ForecastWeather
            {
                City = city,
                DailyTemperatures = dailyAverages,
                DailyDays=days
            };
        }
    }

}
