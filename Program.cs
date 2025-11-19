

using GruppProjectAPI.Business;
using GruppProjectAPI.Services;
builder.Services.AddHttpClient<IWeatherService, OpenMeteoService>();
builder.Services.AddScoped<WeatherBusinessService>();

