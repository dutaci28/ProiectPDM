using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDM.Model
{
    [Table("Inchiriere")]
    public class Inchiriere
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdEchipament { get; set; }
        public string DataInchiriere { get; set; }

    }
}
