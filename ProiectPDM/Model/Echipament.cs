using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDM.Model
{
    [Table("Echipament")]
    public class Echipament
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Denumire { get; set; }
        public TipMarime Marime { get; set; }
        public TipCategorie Categorie { get; set; }
        public float Pret { get; set; }

    }

    public enum TipMarime
    {
        XS,S,M,L,XL
    }

    public enum TipCategorie
    {
        Ski,SnowBoard,Sanie
    }

}
