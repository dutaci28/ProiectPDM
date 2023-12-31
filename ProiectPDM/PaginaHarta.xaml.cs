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
        DisplayAlert("V-ati delogat cu succes!", "", "OK");
        Shell.Current.GoToAsync("//LoginPage");
    }
}