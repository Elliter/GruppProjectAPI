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
        [JsonPropertyName("tiden")]
        public List<string> Time { get; set; }
        [JsonPropertyName("temperatur_2m")]
        public List<double> Temperature2m { get; set; }
        [JsonPropertyName("nederbörd")]
        public List<double> Precipitation { get; set; }
    }
}