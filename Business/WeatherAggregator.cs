using System.Linq;
using System.Threading.Tasks;
using GruppProjectAPI.Models;
using GruppProjectAPI.Services;

namespace GruppProjectAPI.Business
{
    public class WeatherAggregator
    {
        private readonly WeatherServiceAPI _service;

        public WeatherAggregator(WeatherServiceAPI service)
        {
            _service = service;
        }

        public async Task<(double avgTemperatur, double avgRain)> GetWeeklyAverages()
        {
            OpenMeteoAPI data = await _service.GetWeeklyFromOpenMeteoAsync();

            if (data?.Hourly?.Temperature2m == null)
                return (0, 0);

            double avgTemp = data.Hourly.Temperature2m.Average();
            double totalPrec = data.Hourly.Precipitation?.Sum() ?? 0;

            double avgDaily = totalPrec / 7.0;

            return (System.Math.Round(avgTemp, 2), System.Math.Round(avgDaily, 2));
        }
    }
}
