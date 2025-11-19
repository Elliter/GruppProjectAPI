using WeatherAPIRazor.Services;

namespace WeatherAPIRazor.Business
{
    public class WeatherBusiness : IWeatherBusiness
    {
        private readonly IPublicDataService _service;

        public WeatherBusiness(IPublicDataService service)
        {
            _service = service;
        }

        public async Task<CombinedWeatherResult> GetCombinedWeatherAsync(string city)
        {
            var current = await _service.GetCurrentWeatherAsync(city);
            var forecast = await _service.GetForecastAsync(city);

            // Business Rule: Calculate average
            float avgForecast = forecast.DailyTemperatures.Average();

            // Business Rule: Filter forecast > average
            var filtered = forecast.DailyTemperatures
                .Where(t => t > avgForecast)
                .ToList();

            return new CombinedWeatherResult
            {
                CurrentTemp = current.Temperature,
                Humidity = current.Humidity,
                ForecastAvgTemp = avgForecast,
                FilteredForecastDays = filtered
            };
        }
    }
}
