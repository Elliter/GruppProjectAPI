using System.Collections.Generic;
using System.Threading.Tasks;
using GruppProjectAPI.Business;
using GruppProjectAPI.Moduler;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GruppProjectAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherManager _manager;

        public List<WeatherResponse> WeatherList { get; set; }
        public double AverageTemp { get; set; }

        public IndexModel(WeatherManager manager)
        {
            _manager = manager;
        }

        public async Task OnGet()
        {
            var cities = new List<string> { "Stockholm", "Gothenburg", "Borås" };
            (WeatherList, AverageTemp) = await _manager.GetMultipleWeathersAsync(cities);
        }
    }
}
