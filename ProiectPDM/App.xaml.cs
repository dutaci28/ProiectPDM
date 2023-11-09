
using ProiectPDM.Data;
using ProiectPDM.Model;

namespace ProiectPDM
{
    public partial class App : Application
    {
        static BazaDate database;
        public static Client currentClient = null;

        public static BazaDate Database
        {
            get
            {
                if (database == null)
                {
                    database = new BazaDate(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BazaDate.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();


            MainPage = new AppShell();
        }

        public void setCurrentClient(Client client)
        {
            currentClient = client;
        }
    }
}