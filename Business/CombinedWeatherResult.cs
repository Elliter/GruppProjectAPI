namespace GruppProjectAPI.Business
{
    public class CombinedWeatherResult
    {
        public float CurrentTemp { get; set; }
        public float ForecastAvgTemp { get; set; }
        public float Humidity { get; set; }

        public List<float>? FilteredForecastDays { get; set; }
    }
}
