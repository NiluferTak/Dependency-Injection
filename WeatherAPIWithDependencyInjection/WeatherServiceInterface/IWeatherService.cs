using WeatherAPIWithDependencyInjection.Models;

namespace WeatherAPIWithDependencyInjection.WeatherServiceInterface
{
	public interface IWeatherService
	{

		List<CityWeather> GetWeatherInfo();
		CityWeather? GetWeatherInfoByCityName(string cityName);
	}
}
