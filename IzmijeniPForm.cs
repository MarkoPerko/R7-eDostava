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
    public partial class IzmijeniPForm : MetroFramework.Forms.MetroForm
    {
        bool lom = true;
        public IzmijeniPForm()
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
            if (box1.Text == "" || box2.Text == "" || box3.Text == "" || box4.Text == "")
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                if (metroRadioButton2.Checked)
                {
                    lom = false;
                }
                DB.OtvoriKonekciju();
                SQLiteCommand c = DB.con.CreateCommand();
                c.CommandText = String.Format(@"UPDATE  Paket SET duzina=@box1, sirina=@box2, visina=@box3, tezina=@box4, lomljivost=@lom WHERE broj_paketa=@box6");

                c.Parameters.AddWithValue("@box1", Convert.ToDecimal(box1.Text));
                c.Parameters.AddWithValue("@box2", Convert.ToDecimal(box2.Text));
                c.Parameters.AddWithValue("@box3", Convert.ToDecimal(box3.Text));
                c.Parameters.AddWithValue("@box4", Convert.ToDecimal(box4.Text));
                c.Parameters.AddWithValue("@lom", lom);
                c.Parameters.AddWithValue("@box6", Convert.ToInt32(box6.Text));

                c.ExecuteNonQuery();
                c.Dispose();

                DB.ZatvoriKonekciju();
                MessageBox.Show("spremljeno", "ok", MessageBoxButtons.OK);
            }
    }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            IzbornikForm novi = new IzbornikForm();
            novi.Show();
            this.Hide();
        }
    }
}
