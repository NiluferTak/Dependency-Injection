using System.Text.Json;
using WeatherAPIWithDependencyInjection.Models;
using static System.Net.WebRequestMethods;

namespace WeatherAPIWithDependencyInjection.WeatherServiceInterface
{
	public class WeatherService : IWeatherService
	{
		//the bussiness logic behind the development is placed in this service file.
		private readonly List<CityWeather> _cities;
		private readonly HttpClient _httpClient;

		public WeatherService(HttpClient httpClient)
		{
			_httpClient = httpClient;

			_cities = new List<CityWeather>();
			InitializeCities();
			
		}

		// Method to initialize _cities list asynchronously


		private void InitializeCities()
		{
			var cityWeather = WeatherInfo(1,1); 
			if (cityWeather != null)
			{
				_cities.Add(cityWeather);
			}

			
		}

		// Synchronous method to get weather info
		public CityWeather WeatherInfo(double latitude, double longitude)
		{
			var request = new HttpRequestMessage(HttpMethod.Get,
			$"https://api.weatherbit.io/v2.0/current?lat={latitude}&lon={longitude}&key=YOUR_API_KEY&include=minutely");

			var response = _httpClient.Send(request);

			if (response.IsSuccessStatusCode)
			{
				using (var stream = response.Content.ReadAsStream())
				{
					var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(stream);

					if (weatherResponse != null && weatherResponse.Data.Any())
					{
						var weatherData = weatherResponse.Data.First();
						return new CityWeather
						{
							CityName = weatherData.CityName,
							TemperatureFahrenheit = weatherData.Temp,
							DateAndTime = weatherData.Datetime,
							Description = weatherData.Weather.Description
						};
					}
				}
			}

			return null;
		}
	

		//implementations of the interface class' methods

		public List<CityWeather> GetWeatherInfo()
		{
			return _cities;
		}

		public CityWeather? GetWeatherInfoByCityName(string cityName)
		{
			CityWeather? weather = _cities.FirstOrDefault(w => w.CityName == cityName);
			return weather;
		}


	}
}
