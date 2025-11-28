namespace GruppProjectAPI.Models
{
    public abstract class BaseWeather
    {

        public string Day { get; set; }
        public string? City { get; set; }
        public abstract float GetPrimaryTemp();
    }
}