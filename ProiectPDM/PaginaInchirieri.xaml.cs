using Newtonsoft.Json;
using ProiectPDM.Model;

namespace ProiectPDM;

public partial class PaginaInchirieri : ContentPage
{
    List<Echipament> listaEchipamente = new List<Echipament>();
    List<Inchiriere> listaInchirieri = new List<Inchiriere>();
    List<Echipament> listaEchipamenteClient = new List<Echipament>();

	public PaginaInchirieri()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        populeazaLista();
    }

    protected async void populeazaLista()
    {
        listaEchipamente.Clear();
        listaInchirieri.Clear();
        listaEchipamenteClient.Clear();

        listaEchipamente = await App.Database.GetEchipamenteAsync();
        listaInchirieri = await App.Database.GetInchirieriAsync();

        foreach (Inchiriere inchiriere in listaInchirieri)
        {
            if (App.currentClient.Id == inchiriere.IdClient)
            {
                foreach (Echipament echipament in listaEchipamente)
                {
                    if (echipament.Id == inchiriere.IdEchipament) listaEchipamenteClient.Add(echipament);
                }
            }
        }

        colViewEchipamente.ItemsSource = listaEchipamenteClient;
    }

    private void JSON_Clicked(object sender, EventArgs e)
    {
        string json = JsonConvert.SerializeObject(listaEchipamenteClient, Formatting.Indented);
        File.WriteAllText((Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Inchirieri.json")), json);
        //File.WriteAllText((Path.Combine("C:\\Users\\dutac\\OneDrive\\Desktop", "Inchirieri.json")), json);
        DisplayAlert("Fisier descarcat","", "OK");
    }

    private void Sterge_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine(sender);
        var context = (Button)sender;
        var item = (Echipament)context.BindingContext;
        var idEchipament = item.Id;

        foreach (Inchiriere inchiriere in listaInchirieri)
        {
            if (App.currentClient.Id == inchiriere.IdClient)
            {
                if (inchiriere.IdEchipament == idEchipament)
                {
                    App.Database.DeleteInchiriereAsync(inchiriere);
                    DisplayAlert("Inchiriere stearsa", "Inchirierea a fost stearsa", "OK");
                    break;
                }
            }
        }
        populeazaLista();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        colViewEchipamente.ItemsSource = null;
        listaEchipamenteClient.Clear();
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

    private void Logout_Clicked(object sender, EventArgs e)
    {
        App.currentClient = null;
        DisplayAlert("Logout succesful", "You have been logged out.", "OK");
        Shell.Current.GoToAsync("//LoginPage");
    }
}