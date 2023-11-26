namespace ProiectPDM;

public partial class PaginaProfil : ContentPage
{
	public PaginaProfil()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Email.Text = "Email: " + App.currentClient.Email;
        Parola.Text = "Parola: " + App.currentClient.Parola;
        Nume.Text = "Nume: " + App.currentClient.Nume;
        Telefon.Text = "Telefon: " + App.currentClient.Telefon;
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