using WeatherAPIRazor.Models;

namespace WeatherAPIRazor.Services
{
    public interface IPublicDataService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(string city);
        Task<ForecastWeather> GetForecastAsync(string city);
    }

}
