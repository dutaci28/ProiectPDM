using ProiectPDM.Model;

namespace ProiectPDM;

public partial class PaginaRegister : ContentPage
{
	public PaginaRegister()
	{
		InitializeComponent();
	}

    private void RegisterButton_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = ParolaEntry.Text;
        string phone = TelefonEntry.Text;
        string name = NameEntry.Text;

        if (IsClientInputValid(email, password, phone, name))
        {
            Client c = new Client { Nume = name, Email = email, Telefon = phone, Parola = password };
            App.Database.SaveClientAsync(c);
            DisplayAlert("Register Successful", "Client with name: " + c.Nume + " was registered. You can now log in.", "OK");
            Shell.Current.GoToAsync("//LoginPage");
        }
        else
        {
            DisplayAlert("Register Failed", "Invalid credentials", "OK");
        }
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//LoginPage");
    }

    private bool IsClientInputValid(string email, string password,string phone, string name)
    {
        return (IsValidEmail(email) && password.Length > 5 && IsDigitsOnly(phone) && phone.Length == 10 && name.Length >= 3);
    }

    private bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    private bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}