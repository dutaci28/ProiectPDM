namespace ProiectPDM;

public partial class PaginaHarta : ContentPage
{
	public PaginaHarta()
	{
		InitializeComponent();
        Image image = new Image
        {
            Source = ImageSource.FromUri(new Uri("https://www.montania.ro/images/gallery/SkiMap/SINAIA_SKI_TOP05.jpg"))
        };
       
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