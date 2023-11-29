using ProiectPDM.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProiectPDM.Data
{
    public class BazaDate
    {
        readonly SQLiteAsyncConnection database;

        public BazaDate(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Echipament>().Wait();
            database.CreateTableAsync<Client>().Wait();
            database.CreateTableAsync<Inchiriere>().Wait();
            //Populeaza_Echipamente();

        }



        public Task<List<Echipament>> GetEchipamenteAsync()
        {
            return database.Table<Echipament>().ToListAsync();
        }

        public Task<Echipament> GetEchipamentAsync(int id)
        {
            return database.Table<Echipament>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEchipamentAsync(Echipament echipament)
        {
            if (echipament.Id != 0)
            {
                return database.UpdateAsync(echipament);
            }
            else
            {
                return database.InsertAsync(echipament);
            }
        }

        public Task<int> DeleteEchipamentAsync(Echipament echipament)
        {
            return database.DeleteAsync(echipament);
        }



        //clienti
        public Task<List<Client>> GetClientiAsync()
        {
            return database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientAsync(int id)
        {
            return database.Table<Client>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.Id != 0)
            {
                return database.UpdateAsync(client);
            }
            else
            {
                return database.InsertAsync(client);
            }
        }

        public Task<int> DeleteClientAsync(Client client)
        {
            return database.DeleteAsync(client);
        }


        //inchirieri
        public Task<List<Inchiriere>> GetInchirieriAsync()
        {
            return database.Table<Inchiriere>().ToListAsync();
        }

        public Task<Inchiriere> GetInchiriereAsync(int id)
        {
            return database.Table<Inchiriere>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveInchiriereAsync(Inchiriere inchiriere)
        {
            if (inchiriere.Id != 0)
            {
                return database.UpdateAsync(inchiriere);
            }
            else
            {
                return database.InsertAsync(inchiriere);
            }
        }

        public Task<int> DeleteInchiriereAsync(Inchiriere inchiriere)
        {
            return database.DeleteAsync(inchiriere);
        }

        public async Task<int> DeleteAllEchipamenteAsync()
        {


            int nr = database.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Inchiriere").Result;
            if (nr == 0)
            {
                await database.DeleteAllAsync<Echipament>();
                await App.Database.SaveEchipamentAsync(new Model.Echipament { Denumire = "Sanie de lemn", Categorie = Model.TipCategorie.Sanie, Marime = Model.TipMarime.XL, Pret = 99.99f });
                await App.Database.SaveEchipamentAsync(new Model.Echipament { Denumire = "Ski Roz", Categorie = Model.TipCategorie.Ski, Marime = Model.TipMarime.L, Pret = 23.99f });
                await App.Database.SaveEchipamentAsync(new Model.Echipament { Denumire = "Snowboard Albastru", Categorie = Model.TipCategorie.SnowBoard, Marime = Model.TipMarime.M, Pret = 56.99f });
                await App.Database.SaveEchipamentAsync(new Model.Echipament { Denumire = "Ski Verde", Categorie = Model.TipCategorie.Ski, Marime = Model.TipMarime.S, Pret = 90.99f });
                await App.Database.SaveEchipamentAsync(new Model.Echipament { Denumire = "Sanie de plastic", Categorie = Model.TipCategorie.Sanie, Marime = Model.TipMarime.XS, Pret = 10.99f });
                return 1;
            }
            return 1;
        }
    } 
}
