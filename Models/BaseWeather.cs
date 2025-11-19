namespace GruppProjectAPI.Models
{
    public abstract class BaseWeather
    {
        public string? City { get; set; }
        public abstract float GetPrimaryTemp();
    }
}