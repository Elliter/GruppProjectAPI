using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GruppProjectAPI.Models;

namespace GruppProjectAPI.Services
{
    public class WeatherService
    {
        private readonly HttpClient _http;
        private const double Latitude = 57.72;
        private const double Longitude = 12.94;
        private readonly string _location;

        public WeatherService(HttpClient http, IConfiguration config)
        {
            var end = DateTime.UtcNow.Date;
            var start = end.AddDays(-7);
            string s = start.ToString("yyyy-MM-dd");
            string e = end.ToString("yyyy-MM-dd");

            _http = http;
            _location = config.GetValue<string>("WeatherStack:Location") ?? "Boras";

            var url = $"https://archive-api.open-meteo.com/v1/archive?latitude={Latitude}&longitude={Longitude}&start_date={s}&end_date={e}&hourly=temperature_2m,precipitation&timezone=Europe%2FStockholm";
        }
    }
}
