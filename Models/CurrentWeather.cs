namespace WeatherAPIRazor.Models
{
   
        public class CurrentWeather : BaseWeather
        {
            public float Temperature { get; set; }
            public float Humidity { get; set; }

            public override float GetPrimaryTemp() => Temperature;
        }
    
}
