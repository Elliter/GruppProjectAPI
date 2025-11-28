using GruppProjectAPI.Models;
using GruppProjectAPI.Services;

namespace GruppProjectAPI.Business
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

            float avgForecast = forecast.DailyTemperatures.Average();

            var filtered = forecast.DailyTemperatures
                .Zip(forecast.DailyDays, (temp, day) => new ForecastWeather
                {
                    Temperature = temp,
                    Day = day,
                    City = city
                })
                .Where(x => x.Temperature > avgForecast)
                .ToList();


            return new CombinedWeatherResult
            {
                CurrentTemp = current.Temperature,
                Humidity = current.Humidity,
                ForecastAvgTemp = avgForecast,
                FilteredForecastDays = filtered,
            };
        }
    }
}
