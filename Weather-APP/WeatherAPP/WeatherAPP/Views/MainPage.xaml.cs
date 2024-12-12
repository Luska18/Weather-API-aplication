using WeatherAPP.Services;
using WeatherAPP.ViewModels;

namespace WeatherAPP.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}