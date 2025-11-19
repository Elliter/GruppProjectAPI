using GruppProjectAPI.Business;
using GruppProjectAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// Inject interface, NOT concrete class
builder.Services.AddHttpClient<IPublicDataService, PublicDataService>();

// Business layer DI
builder.Services.AddScoped<IWeatherBusiness, WeatherBusiness>();



// register HttpClient and WeatherService....................
//builder.Services.AddHttpClient<WeatherService>();..........


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
