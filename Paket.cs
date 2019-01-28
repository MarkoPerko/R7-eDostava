using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;


namespace Projekt
{
    public class Paket
    {

        public int brojpaketa { get; set; }
        public int visina { get; set; }
        public int sirina { get; set; }
        public int duzina { get; set; }
        public int tezina { get; set; }
        public int BrojN { get; set; }
        public int? BrojV { get; set; }

       
        public static List<Paket> DohvatiPaket()
        {
            
            var lista = new List<Paket>();
            DB.OtvoriKonekciju();
            SQLiteCommand c = DB.con.CreateCommand();
            c.CommandText = String.Format(@" SELECT broj_paketa, visina, duzina, sirina, tezina, lomljivost, BrojN, BrojV FROM Paket");
            SQLiteDataReader reader = c.ExecuteReader();
            while (reader.Read())
            {
                Paket a = new Paket();
                a.brojpaketa = Convert.ToInt32(reader["broj_paketa"]);
                a.visina = Convert.ToInt32(reader["visina"]);
                a.duzina = Convert.ToInt32(reader["duzina"]);
                a.sirina = Convert.ToInt32(reader["sirina"]);
                a.tezina = Convert.ToInt32(reader["tezina"]);
                a.BrojN = Convert.ToInt32(reader["BrojN"]);
                //a.BrojV = Convert.ToInt32(reader["BrojV"]);
                lista.Add(a);

            }
          
            DB.ZatvoriKonekciju();
            return lista;
        }
       

   
    }
}
