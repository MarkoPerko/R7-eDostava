using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;



namespace Projekt
{
    public class Narudzba
    {
        public int IDNarudzbe { get; set; }
        public int DatumN { get; set; }
        public int DatumD { get; set; }
        public string adresaP { get; set; }
        public string adresaD { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }

        public static List<Narudzba> DohvatiNarudzbu()
        {
            DB.OtvoriKonekciju();
            var lista = new List<Narudzba>();
            SQLiteCommand c = DB.con.CreateCommand();
            c.CommandText = String.Format(@" SELECT broj_narudzbe, datum_narudzbe, datum_isporuke, adresa_p, adresa_d, ime, prezime FROM Narudzba");
            SQLiteDataReader reader = c.ExecuteReader();
            while (reader.Read())
            {
                Narudzba a = new Narudzba();
                a.IDNarudzbe = Convert.ToInt32(reader["broj_narudzbe"]);
                a.DatumN = Convert.ToInt32(reader["datum_narudzbe"]);
                a.DatumD = Convert.ToInt32(reader["datum_isporuke"]);
                a.adresaD = Convert.ToString(reader["adresa_d"]);
                a.ime = Convert.ToString(reader["ime"]);
                a.prezime = Convert.ToString(reader["prezime"]);
                lista.Add(a);
               
            }
            c.Dispose();
            DB.ZatvoriKonekciju();
            return lista;
        }
       
       

           

    }
}
