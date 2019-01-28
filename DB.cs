using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projekt
{
    public static class DB
    {
        private static string connectionString = "Data Source = baza.db3";

        internal static SQLiteConnection con = new SQLiteConnection(connectionString);

        internal static void OtvoriKonekciju()
        {
            con.Open();
        }

        internal static void ZatvoriKonekciju()
        {
            con.Close();
        }

   


    }
}
