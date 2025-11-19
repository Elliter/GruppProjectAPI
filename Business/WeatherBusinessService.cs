using GruppProjectAPI.Models;

namespace GruppProjectAPI.Business;

public class WeatherBusinessService
{
    /// <summary>
    /// Beräknar medeltemperatur för nästa n timmar (från hourly).
    /// </summary>
    public double? CalculateMeanHourlyTemperature(WeatherResponseDto dto, int hours)
    {
        if (dto?.Hourly?.Temperature_2m == null) return null;
        var temps = dto.Hourly.Temperature_2m.Take(hours).ToList();
        if (!temps.Any()) return null;
        return temps.Average();
    }

    /// <summary>
    /// Konverterar DTO -> business model som kan användas polymorfiskt
    /// (ex: BaseForecast med HourlyForecast / DailyForecast)
    /// </summary>
    public BaseForecast CreateForecastModel(WeatherResponseDto dto)
    {
        return new HourlyForecast(dto.Hourly, dto.Current_Weather);
    }
}
