using WeatherAPIWithDependencyInjection.WeatherServiceInterface;
using WeatherServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//IoC container should have the object of weather service so that it will provide that
//when controller asks the object that implements the related service interface which is in our case IWeatherService.
builder.Services.AddHttpClient();
builder.Services.AddTransient<IWeatherService, WeatherService>();

//for static files such as stylessheet.css
app.UseStaticFiles();
// for routing
app.UseRouting();
//for using controllers
app.MapControllers();

app.Run();
