using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GruppProjectAPI.Moduler;
using GruppProjectAPI.Services;

namespace GruppProjectAPI.Business
{
    public class WeatherManager
    {
        private readonly IWeatherService _weatherService;

        public WeatherManager(IWeatherService service)
        {
            _weatherService = service;
        }

        // Hämtar väder för flera städer och räknar genomsnittstemperatur
        public async Task<(List<WeatherResponse>, double)> GetMultipleWeathersAsync(List<string> cities)
        {
            var list = new List<WeatherResponse>();

            foreach (var c in cities)
            {
                var w = await _weatherService.GetWeatherAsync(c);
                list.Add(w);
            }

            var avg = list.Average(w => w.current.temperature);
            return (list, avg);
        }
    }
}
