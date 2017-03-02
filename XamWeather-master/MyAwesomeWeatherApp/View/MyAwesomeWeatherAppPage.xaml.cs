using Xamarin.Forms;

namespace MyAwesomeWeatherApp
{
	public partial class MyAwesomeWeatherAppPage : ContentPage
	{
		public MyAwesomeWeatherAppPage()
		{
			InitializeComponent();
		}

		async void launchSearchByCity(object sender, System.EventArgs e)
		{
			if (!entryCity.Text.Equals(""))
			{
				await Navigation.PushAsync(new WeatherDisplayingPage(entryCity.Text));
			}
			else {
				await DisplayAlert("Champs ville vide", "Entrer une ville puis ressayer !", "Close");
			}
		}

		async void launchSearchByPosition(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new WeatherDisplayingPage("gps"));
		}

	}
}
