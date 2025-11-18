using GruppProjectAPI.Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GruppProjectAPI.Business;

namespace GruppProjectAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherAggregator _agg;
        public double AvgTemp { get; set; }
        public double AvgRain { get; set; }
        public bool Failed { get; set; }

        public IndexModel(WeatherAggregator agg) { _agg = agg; }

        public async Task OnGet()
        {

        }
    }
}
