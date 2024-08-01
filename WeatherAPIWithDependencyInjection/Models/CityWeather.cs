using System.Text.Json.Serialization;

namespace WeatherAPIWithDependencyInjection.Models
{
	public class CityWeather
	{
		#region properties

		public string ? CityName { get; set; }
		public string DateAndTime { get; set; }
		public double TemperatureFahrenheit { get; set; }
		public string Description { get; set; }

		#endregion
	}

	public class WeatherResponse
	{
		[JsonPropertyName("data")]
		public List<WeatherData> Data { get; set; }
	}

	public class WeatherData
	{
		[JsonPropertyName("city_name")]
		public string CityName { get; set; }

		[JsonPropertyName("temp")]
		public double Temp { get; set; }

		[JsonPropertyName("datetime")]
		public string Datetime { get; set; }

		[JsonPropertyName("weather")]
		public WeatherInfo Weather { get; set; }
	}

	public class WeatherInfo
	{
		[JsonPropertyName("description")]
		public string Description { get; set; }
	}
}
