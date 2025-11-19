using GruppProjectAPI.Business;
using GruppProjectAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<WeatherServiceAPI>();
builder.Services.AddScoped<WeatherAggregator>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
