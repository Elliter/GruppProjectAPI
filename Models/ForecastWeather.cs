namespace GruppProjectAPI.Models
{
    public class ForecastWeather : BaseWeather
    {
        public List<float> DailyTemperatures { get; set; } = new();

        public override float GetPrimaryTemp() =>
            DailyTemperatures.Count > 0 ? DailyTemperatures[0] : 0;
    }
}
