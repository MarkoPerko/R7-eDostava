using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Projekt
{
    public partial class IzmijeniNForm : MetroFramework.Forms.MetroForm
    {
      
        public IzmijeniNForm()
        {
            InitializeComponent();
        }

    

        private void metroButton1_Click(object sender, EventArgs e)
        {
            IzbornikForm novi = new IzbornikForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "")
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                DB.OtvoriKonekciju();
                SQLiteCommand c = DB.con.CreateCommand();
                c.CommandText = String.Format(@"UPDATE  Narudzba SET adresa_d=@box2, ime=@box3, prezime=@box4 WHERE broj_narudzbe=@box1");

                c.Parameters.AddWithValue("@box2", metroTextBox2.Text);
                c.Parameters.AddWithValue("@box3", metroTextBox3.Text);
                c.Parameters.AddWithValue("@box4", metroTextBox4.Text);
                c.Parameters.AddWithValue("@box1", Convert.ToInt32(metroTextBox1.Text));

                c.ExecuteNonQuery();
                c.Dispose();

                DB.ZatvoriKonekciju();
                MessageBox.Show("spremljeno", "ok", MessageBoxButtons.OK);
            }
        }
    }
}
