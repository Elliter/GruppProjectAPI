using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GruppProjectAPI.Models
{
    public class OpenMeteoAPI
    {
        [JsonPropertyName("hourly")]
        public HourlyData Hourly { get; set; }
    }

    public class HourlyData
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }
        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature2m { get; set; }
        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; }
    }

    // här anropas från Open Meteo API till klasser ovan.

    public class WeatherDayAPI
    {
        public double Temperature { get; set; }
        public double Precipitation { get; set; }
    }
}