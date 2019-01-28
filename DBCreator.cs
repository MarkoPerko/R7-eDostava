using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projekt
{
    public static class DBCreator
    {
        public static void DBreg()
        {
            SQLiteCommand com = DB.con.CreateCommand();

            com.CommandText = @"CREATE TABLE IF NOT EXISTS Registracija(
                                        id integer primary key autoincrement, 
                                        vrsta_korisnika varchar(20), 
                                        ime varchar(20),
                                        prezime varchar(20),
                                        username varchar(20),
                                        password varchar(20),
                                        email varchar(30))";

            com.ExecuteNonQuery();

            com.Dispose();

        }

        public static void DBNarudzba()
        {
            SQLiteCommand com = DB.con.CreateCommand();

            com.CommandText = @"CREATE TABLE IF NOT EXISTS Narudzba (
                                        broj_narudzbe integer primary key autoincrement, 
                                        datum_narudzbe integer,
                                        datum_isporuke integer,
                                        adresa_p varchar(50), 
                                        adresa_d varchar(50),
                                        ime varchar(20),
                                        prezime varchar(20),
                                        status_paketa varchar(30))";
           
            com.ExecuteNonQuery();
            com.Dispose();
        }

        public static void DBPaket()
        {
            SQLiteCommand com = DB.con.CreateCommand();

            com.CommandText = @"CREATE TABLE IF NOT EXISTS Paket (
                                        broj_paketa integer primary key autoincrement,
                                        duzina float,
                                        visina float,
                                        sirina float,
                                        tezina float, 
                                        lomljivost bool,
                                        BrojN integer,
                                        brojV varchar(20))";

            

            com.ExecuteNonQuery();
            com.Dispose();
        }

        public static void DBVozila()
        {

            SQLiteCommand com = DB.con.CreateCommand();

            com.CommandText = @"CREATE TABLE IF NOT EXISTS Vozila (
                                        id_vozila integer primary key autoincrement, 
                                        registracija varchar(20),
                                        kapacitet integer
                                        )";

            com.ExecuteNonQuery();
            com.Dispose();


        }



    }
}
