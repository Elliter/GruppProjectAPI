using  System.Threading.Tasks;

public interface IWeatherService

{
    /// <summary>
    /// Hämtar väder data (current, hourly, daily) för en given plats.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    Task<string> GetWeatherAsync(string location);
}