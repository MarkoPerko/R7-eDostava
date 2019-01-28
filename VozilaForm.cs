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
    public partial class VozilaForm : MetroFramework.Forms.MetroForm
    {
       
        public VozilaForm()
        {
            InitializeComponent();
        }



      

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (registracija.Text=="" || kapacite.Text=="")
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {


                DB.OtvoriKonekciju();

                DBCreator.DBVozila();

                SQLiteCommand c = DB.con.CreateCommand();
                c.CommandText = String.Format(@"INSERT INTO Vozila (registracija, kapacitet) VALUES (@registracija, @kapacitet)");

                c.Parameters.AddWithValue("@registracija", registracija.Text);
                c.Parameters.AddWithValue("@kapacitet", kapacite.Text);

                c.ExecuteNonQuery();
                c.Dispose();

                DB.ZatvoriKonekciju();
                MessageBox.Show("spremljeno", "ok", MessageBoxButtons.OK);
                
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            IzbornikForm nazad = new IzbornikForm();
            nazad.Show();
            this.Hide();
        }
    }
}
