public class HourlyForecast : BaseForecast
{
    public HourlyDto? Hourly { get; set; }
    public CurrentWeather? Current { get; set; }

    public HourlyForecast(HourlyDto? hourly, CurrentWeather? current)
    {
        Type = "Hourly";
        Hourly = hourly;
        Current = current;
    }
}
