namespace ProiectPDM;

public partial class PaginaAcasa : ContentPage
{
	public PaginaAcasa()
	{
		InitializeComponent();
        Image image = new Image
        {
            Source = ImageSource.FromUri(new Uri("https://static.vecteezy.com/system/resources/previews/004/231/994/original/young-man-riding-on-skis-masked-winter-flat-illustration-in-cartoon-style-winter-sport-activities-illustration-winter-landscape-vector.jpg"))
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