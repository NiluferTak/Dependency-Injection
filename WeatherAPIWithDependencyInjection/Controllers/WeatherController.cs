using Microsoft.AspNetCore.Mvc;
using WeatherAPIWithDependencyInjection.WeatherServiceInterface;

namespace WeatherAPIWithDependencyInjection.Controllers
{
	public class WeatherController : Controller
	{

		// to hold reference to the service instance that will be created via dependency injection
		private readonly IWeatherService _weatherService;

		//get the service instance through a constructor parameter
		public WeatherController(IWeatherService weatherService)
		{
			_weatherService = weatherService;
		}

		// handling the requests aka middlewares

		[Route("/")]
		public IActionResult Index()
		{
			var cities = _weatherService.GetWeatherInfo();
			return View(cities);
		}

		[Route("/weather/{cityName}")]
		public IActionResult City(string? cityName)
		{
			if (string.IsNullOrEmpty(cityName))
				return View();

			var city = _weatherService.GetWeatherInfoByCityName(cityName);
			return View(city);
		}
	}
}
