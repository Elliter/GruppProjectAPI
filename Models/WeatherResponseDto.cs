public class WeatherResponseDto
{
    public CurrentWeather? Current_Weather { get; set; }
    public HourlyDto? Hourly { get; set; }
    public DailyDto? Daily { get; set; }
    public string? Timezone { get; set; }
}

public class CurrentWeather
{
    public double Temperature { get; set; }
    public double Windspeed { get; set; }
    public int Weathercode { get; set; }
    public string? Time { get; set; }
}

public class HourlyDto
{
    public List<string>? Time { get; set; }
    public List<double>? Temperature_2m { get; set; }
    public List<double>? Relativehumidity_2m { get; set; }
}

public class DailyDto
{
    public List<string>? Time { get; set; }
    public List<double>? Temperature_2m_max { get; set; }
    public List<double>? Temperature_2m_min { get; set; }
}
