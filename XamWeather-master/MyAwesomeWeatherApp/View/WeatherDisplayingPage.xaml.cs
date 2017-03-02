using System;
using System.Collections.Generic;
using OpenWeatherApi;
using Plugin.Geolocator;
using Xamarin.Forms;
using System.Diagnostics;

namespace MyAwesomeWeatherApp
{
	public partial class WeatherDisplayingPage : ContentPage
	{
		private string cityName;

		public WeatherDisplayingPage(string data)
		{
			InitializeComponent();

			if (data.Equals("gps"))
			{
				getWeatherByPosition();
			}
			else {
				getWeatherByCity(data);
			}
		}

		private async void getWeatherByCity(string city)
		{
			WeatherManager wManager = new WeatherManager();
			Ville ville = await wManager.GetWeather(city);
			cityLabel.Text += ville.name;
			tempLabel.Text += (int)ville.main.temp + " °C";
			descriptionLabel.Text = ville.weather[0].description;
		}

		private async void getWeatherByPosition()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var position = await locator.GetPositionAsync(10000);

			Debug.WriteLine("Lat : "+position.Latitude);
			Debug.WriteLine("Lat : " + position.Longitude);

			WeatherManager wManager = new WeatherManager();
			Ville ville = await wManager.GetWeatherGps(position.Latitude,position.Longitude);
			cityLabel.Text += ville.name;
			tempLabel.Text += (int)ville.main.temp + " °C";
			descriptionLabel.Text = ville.weather[0].description;
		}
	}
}
