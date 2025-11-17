using System.Threading.Tasks;
using GruppProjectAPI.Moduler;

namespace GruppProjectAPI.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string city);
    }
}
