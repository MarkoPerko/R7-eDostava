using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net;
using System.IO;


namespace Projekt
{
    public class Dashboard
    {
        public int IDNarudzbe { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public string status_paketa { get; set; }
        public int id_vozila { get; set; }
        


        public static List<Dashboard> DohvatiPodatke()
        {

            DB.OtvoriKonekciju();

            var podaci = new List<Dashboard>();

            SQLiteCommand c = DB.con.CreateCommand();
            c.CommandText = String.Format(@"SELECT * FROM Narudzba, Vozila");
            SQLiteDataReader reader = c.ExecuteReader();
           


            while (reader.Read())
            {
                Dashboard a = new Dashboard();
                a.IDNarudzbe =(int) Convert.ToInt32(reader["broj_narudzbe"]);
                a.adresa = (string) Convert.ToString(reader["adresa_d"]);
                a.ime = (string) Convert.ToString(reader["ime"]);
                a.prezime = (string) Convert.ToString(reader["prezime"]);
                a.id_vozila = (int)Convert.ToInt32(reader["id_vozila"]);
                a.status_paketa = (string)Convert.ToString(reader["status_paketa"]);

                podaci.Add(a);
                
            }

           

            c.Dispose();

            DB.ZatvoriKonekciju();

            return podaci;
        }

       


    }
}
 