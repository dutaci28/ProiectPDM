using Microcharts;
using Microcharts.Maui;
using ProiectPDM.Services;
using SkiaSharp;

namespace ProiectPDM;

public partial class PaginaStatistici : ContentPage
{
    private readonly VremeService _weatherService = new VremeService();

    public PaginaStatistici()
	{
		InitializeComponent();
        LoadWeatherData();
    }

    private async void LoadWeatherData()
    {
        base.OnAppearing();

        var weatherData = await _weatherService.GetWeatherDataAsync("Sinaia");

        var entries = new List<ChartEntry>();
        foreach (var item in weatherData)
        {
            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(item.dt).DateTime;

            ChartEntry entry = new ChartEntry((float)item.main.temp)
            {
                Label = dateTime.ToString("MMM dd - hh : mm"),
                ValueLabel = item.main.temp.ToString()
            };
            entries.Add(entry);

            chartView1.Chart = new LineChart
            {
                Entries = entries
            };
        }
    }

    private void Statisticii_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaStatistici");
    }
    private void Acasa_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaAcasa");
    }
    private void Disponibile_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaEchipamente");
    }

    private void Inchirieri_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaInchirieri");
    }

    private void Profil_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaProfil");
    }

    private void Informatii_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaHarta");
    }

    private void Logout_Clicked(object sender, EventArgs e)
    {
        App.currentClient = null;
        DisplayAlert("Logout succesful", "You have been logged out.", "OK");
        Shell.Current.GoToAsync("//LoginPage");
    }
}