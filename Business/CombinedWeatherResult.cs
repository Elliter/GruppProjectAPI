using GruppProjectAPI.Models;

namespace GruppProjectAPI.Business
{
    public class CombinedWeatherResult
    {
        public float CurrentTemp { get; set; }
        public float ForecastAvgTemp { get; set; }
        public float Humidity { get; set; }

        //  public List<CurrentWeather>? FilteredForecastDays { get; set; }
        // public List<string>? FilteredForecastWDays { get; set; }
        public List<ForecastWeather>? FilteredForecastDays { get; set; }
    }
}
