public class DailyForecast : BaseForecast
{
    public DailyDto? Daily { get; set; }

    public DailyForecast(DailyDto? daily)
    {
        Type = "Daily";
        Daily = daily;
    }
}
