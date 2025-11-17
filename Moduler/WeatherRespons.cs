namespace GruppProjectAPI.Moduler
{
    public class WeatherResponse
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
    }

    public class Current
    {
        public double temperature { get; set; }
        public string[] weather_descriptions { get; set; }
    }
}
