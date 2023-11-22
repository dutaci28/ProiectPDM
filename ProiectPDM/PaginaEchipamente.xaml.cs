using Microsoft.Maui.Controls;
using ProiectPDM.Model;


namespace ProiectPDM;

public partial class PaginaEchipamente : ContentPage
{
	public PaginaEchipamente()
	{
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await App.Database.SaveEchipamentAsync(new Model.Echipament { Denumire = "Sanie de lemn", Categorie = Model.TipCategorie.Sanie, Marime = Model.TipMarime.XL, Pret = 99.99f });
        //await App.Database.SaveInchiriereAsync(new Model.Inchiriere { IdClient=2,IdEchipament=1,DataInchiriere="09.11.2023" });
        colViewEchipamente.ItemsSource = await App.Database.GetEchipamenteAsync();
    }
    
    private void Inchiriaza_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine(sender);
        var context = (Button)sender;
        var item = (Echipament)context.BindingContext;
        var id = item.Id;
        App.Database.SaveInchiriereAsync(new Inchiriere { IdClient=App.currentClient.Id,IdEchipament=id,DataInchiriere=DateTime.Now.ToString() });
        DisplayAlert("Inchiriere cu succes", "Echipamentul " + item.Denumire + " a fost inchiriat.", "OK");
    }

    private void Disponibile_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaEchipamente");
    }

    private void Inchirieri_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaInchirieri");
    }
    

  private void Informatii_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaHarta");
    }
    private void Profil_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PaginaProfil");
    }

    private void Logout_Clicked(object sender, EventArgs e)
    {
        App.currentClient = null;
        DisplayAlert("Logout succesful", "You have been logged out.", "OK");
        Shell.Current.GoToAsync("//LoginPage");
    }
}