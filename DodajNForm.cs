using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace Projekt
{
    public partial class DodajNForm : MetroFramework.Forms.MetroForm
    {
        
        
        public DodajNForm()
        {
            InitializeComponent();

            timer1.Start();
        }


       

        private static void Povecaj_Datum(DateTime VrijemDostave)
        {
            VrijemDostave.AddDays(3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.Datum.Text = time.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (AdresaDTXT.Text == "" || ImeTXT.Text == "" || PrezimeTXT.Text == "")
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                var AdresaP = "centar";



                DB.OtvoriKonekciju();

                DBCreator.DBNarudzba();


                SQLiteCommand c = DB.con.CreateCommand();
                c.CommandText = String.Format(@"INSERT INTO Narudzba(datum_narudzbe, datum_isporuke, adresa_p, adresa_d, ime, prezime) VALUES (@datum_narudzbe, @datum_isporuke, @adresa_p, @adresa_d, @ime, @prezime)");

                c.Parameters.AddWithValue("@datum_narudzbe", DateTime.Today);
                c.Parameters.AddWithValue("@datum_isporuke", DateTime.Today.AddDays(3));
                c.Parameters.AddWithValue("@adresa_p", AdresaP);
                c.Parameters.AddWithValue("@adresa_d", AdresaDTXT.Text);
                c.Parameters.AddWithValue("@ime", ImeTXT.Text);
                c.Parameters.AddWithValue("@prezime", PrezimeTXT.Text);

                c.ExecuteNonQuery();
                c.Dispose();





                MessageBox.Show("narudzba je spremljena", "ok", MessageBoxButtons.OK);

                DB.ZatvoriKonekciju();

                DodajPForm novi = new DodajPForm();
                novi.Show();
                this.Hide();


            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            IzbornikForm novi = new IzbornikForm();
            novi.Show();
            this.Hide();
        }
    }
}