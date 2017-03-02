using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Diagnostics;

namespace OpenWeatherApi
{
	public class WeatherManager
	{
		const String urlCity = "http://api.openweathermap.org/data/2.5/weather?q=";
		const String urlGps = "http://api.openweathermap.org/data/2.5/weather?";
		const String apiEntry = "&units=metric&APPID=392f97bedf3eb4f221161c2a476aa0d3";

		public async Task<Ville> GetWeather(string queryCity)
		{
			HttpClient httpClient = new HttpClient();
			string weatherResult = await httpClient.GetStringAsync(urlCity+queryCity+apiEntry);

			Debug.WriteLine(weatherResult);

			return JsonConvert.DeserializeObject<Ville>(weatherResult);
		}

		public async Task<Ville> GetWeatherGps(double lat, double lon)
		{
			string positionQuery = "lat=" + lat + "&lon=" + lon;

			HttpClient httpClient = new HttpClient();
			string weatherResult = await httpClient.GetStringAsync(urlGps + positionQuery + apiEntry);

			Debug.WriteLine(weatherResult);

			return JsonConvert.DeserializeObject<Ville>(weatherResult);
		}
	}
}

