using GruppProjectAPI.Models;

using System.Net.Http;
using System.Text.Json;

namespace GruppProjectAPI.Services;


public class OpenMeteoService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public OpenMeteoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherResponseDto?> GetWeatherAsync(double lat, double lon, string timezone = "auto")
    {
        try
        {
            // Exempel: hourly temperature_2m, daily temperature_2m_max
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m,relativehumidity_2m&daily=temperature_2m_max,temperature_2m_min&current_weather=true&timezone={timezone}";
            using var resp = await _httpClient.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<WeatherResponseDto>(json, _jsonOptions);
            return dto;
        }
        catch (HttpRequestException hrex)
        {
            // logga eller further handling, returnera null eller ett "tomt" DTO
            Console.WriteLine($"HTTP error: {hrex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            return null;
        }
    }
}
