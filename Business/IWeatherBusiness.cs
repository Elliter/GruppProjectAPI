namespace WeatherAPIRazor.Business
{
    public interface IWeatherBusiness
    {
        Task<CombinedWeatherResult> GetCombinedWeatherAsync(string city);
    }
}
