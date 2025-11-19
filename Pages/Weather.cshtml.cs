using GruppProjectAPI.Models;
using GruppProjectAPI.Business;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class WeatherModel : PageModel
{
    private readonly IWeatherService _weatherService;
    private readonly WeatherBusinessService _business;

    [BindProperty]
    public double Latitude { get; set; } = 59.3293; // Stockholm default
    [BindProperty]
    public double Longitude { get; set; } = 18.0686;

    public WeatherResponseDto? Weather { get; set; }
    public BaseForecast? ForecastModel { get; set; }
    public double? MeanNext12Hours { get; set; }

    public WeatherModel(IWeatherService weatherService, WeatherBusinessService business)
    {
        _weatherService = weatherService;
        _business = business;
    }

    public async Task OnPostAsync()
    {
        Weather = await _weatherService.GetWeatherAsync(Latitude, Longitude);
        if (Weather != null)
        {
            ForecastModel = _business.CreateForecastModel(Weather);
            MeanNext12Hours = _business.CalculateMeanHourlyTemperature(Weather, 12);
        }
    }
}
