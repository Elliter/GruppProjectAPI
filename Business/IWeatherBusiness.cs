namespace GruppProjectAPI.Business
{
    public interface IWeatherBusiness
    {
        Task<CombinedWeatherResult> GetCombinedWeatherAsync(string city);
    }
}
