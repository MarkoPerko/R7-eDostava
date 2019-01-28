using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projekt
{

    public class vozila
    {
        public int ID { get; set; }
        public string registracija { get; set; }
        public int kapacitet { get; set; }
       
    public static List<vozila> DohvatiVozila()
        {
            DB.OtvoriKonekciju();
            var lista = new List<vozila>();
            SQLiteCommand c = DB.con.CreateCommand();
            c.CommandText = String.Format(@" SELECT id_vozila, registracija, kapacitet FROM Vozila");
            SQLiteDataReader reader = c.ExecuteReader();
            while (reader.Read())
            {
                vozila a = new vozila();
                a.ID = Convert.ToInt32(reader["id_vozila"]);
                a.registracija = Convert.ToString(reader["registracija"]);
                a.kapacitet = Convert.ToInt32(reader["kapacitet"]);
           
                lista.Add(a);

            }
            c.Dispose();
            DB.ZatvoriKonekciju();
            return lista;
        }
        public static int Najmanji()
        {
            List<vozila> listavozila = vozila.DohvatiVozila();
            var min=100;
            foreach (var a in listavozila)
            {
                if(a.ID < min)
                {
                    min = a.ID;
                }
            }
            return min;

        }
    
        
        public static void Rasporedi_pakete( string BrojV)
        {
            List<vozila> listaVozila = vozila.DohvatiVozila();
            List<Paket> listaPaketa = Paket.DohvatiPaket();
            List<Narudzba> listaNarudzbi = Narudzba.DohvatiNarudzbu();
            
            foreach (var a in listaNarudzbi)
            {
                foreach (var b in listaPaketa)
                {
                    if (b.BrojV == null)
                    {
                        foreach (var d in listaVozila)
                        {

                            b.BrojV = Convert.ToInt32(BrojV);
                            DB.OtvoriKonekciju();
                            SQLiteCommand c = DB.con.CreateCommand();
                            c.CommandText = String.Format(@"UPDATE Paket SET BrojV = @BrojV WHERE broj_paketa = @brojP");
                            c.Parameters.AddWithValue("@BrojV", b.BrojV);
                            c.Parameters.AddWithValue("@brojP", b.brojpaketa);
                            c.ExecuteNonQuery();
                            c.Dispose();

                            DB.ZatvoriKonekciju();
                        } 
                    }
                    
                }
            }
        }
    }
}
