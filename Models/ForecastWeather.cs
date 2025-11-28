namespace GruppProjectAPI.Models
{
    public class ForecastWeather : BaseWeather
    {
        public float Temperature { get; set; }
        public List<float> DailyTemperatures { get; set; } = new();
        public List<string> DailyDays { get; set; } = new();

        public override float GetPrimaryTemp() => Temperature;
    }
}
