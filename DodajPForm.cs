using System;
using System.Collections.Generic;
using System.ComponentModel ;
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
    public partial class DodajPForm : MetroFramework.Forms.MetroForm
    {

        bool lom = true;
        public List<Narudzba> narudzbas;
        public DodajPForm()
        {
            InitializeComponent();
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "")
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                if (metroRadioButton2.Checked)
                {
                    lom = false;
                }
                narudzbas = Narudzba.DohvatiNarudzbu();
                var zadnji = narudzbas.Last();

                DB.OtvoriKonekciju();
                SQLiteCommand c = DB.con.CreateCommand();

                c.CommandText = String.Format(@"INSERT INTO Paket(sirina, duzina, visina, tezina, lomljivost, BrojN ) VALUES (@sirina, @duzina, @visina, @tezina, @lomljivost, @BrojN)");


                c.Parameters.AddWithValue("@sirina", metroTextBox1.Text);
                c.Parameters.AddWithValue("@duzina", metroTextBox2.Text);
                c.Parameters.AddWithValue("@visina", metroTextBox3.Text);
                c.Parameters.AddWithValue("@tezina", metroTextBox4.Text);
                c.Parameters.AddWithValue("@lomljivost", lom);
                c.Parameters.AddWithValue("@BrojN", zadnji.IDNarudzbe);


                
                c.ExecuteNonQuery();
                c.Dispose();
                MessageBox.Show("spremljeno", "ok", MessageBoxButtons.OK);
                
                DB.ZatvoriKonekciju();
               
                IzbornikForm novi = new IzbornikForm();
                novi.Show();
                this.Hide();




            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DodajPForm novi = new DodajPForm();
            novi.Show();
            this.Hide();

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DodajNForm novi = new DodajNForm();
            novi.Show();
            this.Hide();
        }
    }
}
