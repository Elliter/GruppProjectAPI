using System.Threading.Tasks;
using GruppProjectAPI.Services;

namespace GruppProjectAPI.Business
{
    public class WeatherAggregator
    {
        private readonly WeatherServiceAPI _service;
        public WeatherAggregator(WeatherServiceAPI service) { _service = service; }

        public async Task<(double avgTemperatur, double avgRain)> GetWeeklyAverages()
        {
            var w = await _service.GetWeeklyFromOpenMeteoAsync();
            if (w == null) 
                return (0, 0);
            return (w.Temperature, w.Precipitation);
        }
    }
}
