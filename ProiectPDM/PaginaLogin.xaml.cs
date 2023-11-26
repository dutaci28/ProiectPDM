namespace ProiectPDM;
using Microsoft.Maui.Controls;
using ProiectPDM.Model;

public partial class PaginaLogin : ContentPage
{

    private List<Client> listaClienti = new List<Client>();
    public PaginaLogin()
    {
        InitializeComponent();
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = ParolaEntry.Text;

        if (IsLoginValid(email, password))
        {
            Shell.Current.GoToAsync("//PaginaAcasa");
        }
        else
        {
            DisplayAlert("Login Failed", "Invalid email or password", "OK");
        }
    }

    private void RegisterButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//RegisterPage");
    }

    private bool IsLoginValid(string email, string password)
    {
        foreach (Client c in listaClienti)
        {
            if (c.Email == email && c.Parola == password)
            {
                App.currentClient = c;
                return true;
            }
        }
        return false;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listaClienti = await App.Database.GetClientiAsync();
    }
}