using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GruppProjectAPI.Business;

namespace GruppProjectAPI.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IWeatherBusiness _business;

        public WeatherModel(IWeatherBusiness business)
        {
            _business = business;
        }

        [BindProperty]
        public string City { get; set; } = "";

        public CombinedWeatherResult? Result { get; set; }

        public async Task<IActionResult> OnPost()
        {
            Result = await _business.GetCombinedWeatherAsync(City);
            return Page();
        }
    }
}
