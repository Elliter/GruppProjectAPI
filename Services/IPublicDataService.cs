using GruppProjectAPI.Models;

namespace GruppProjectAPI.Services
{
    public interface IPublicDataService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(string city);
        Task<ForecastWeather> GetForecastAsync(string city);
    }

}
