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
    public partial class RegistracijaForm : MetroFramework.Forms.MetroForm
    {
        public RegistracijaForm()
        {
            InitializeComponent();
        }

    

    

        private void metroButton1_Click(object sender, EventArgs e)
        {
            LoginForm izlaz = new LoginForm();
            izlaz.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (box1.Text == "" || box2.Text == "" || box3.Text == "" || box4.Text == "" || box5.Text == "")
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            { 
                DB.OtvoriKonekciju();

                DBCreator.DBreg();

                SQLiteCommand c = DB.con.CreateCommand();
                c.CommandText = String.Format(@"INSERT INTO Registracija (vrsta_korisnika, ime, prezime, username, password, email) VALUES (@vrsta_korisnika, @ime, @prezime, @username, @password, @email)");

                c.Parameters.AddWithValue("@vrsta_korisnika", box1.Text);
                c.Parameters.AddWithValue("@ime", box2.Text);
                c.Parameters.AddWithValue("@prezime", box3.Text);
                c.Parameters.AddWithValue("@username", box4.Text);
                c.Parameters.AddWithValue("@password", box5.Text);
                c.Parameters.AddWithValue("@email", box6.Text);

                c.ExecuteNonQuery();
                c.Dispose();


                DB.ZatvoriKonekciju();
                MessageBox.Show("spremljeno","ok", MessageBoxButtons.OK);
            }
        }

        

        private void box6_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (box6.Text.Length > 0)
            {
                if (!rEmail.IsMatch(box6.Text))
                {
                    MessageBox.Show("neispravna email adresa ", "ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    box6.SelectAll();
                    e.Cancel = true;
                    
                }
            }
        }
        private void box4_Validating(object sender, CancelEventArgs e)
        {
            DB.OtvoriKonekciju();
            SQLiteCommand c = DB.con.CreateCommand();

            c.CommandText = ("SELECT count(*) FROM Registracija WHERE username = '" + box4.Text + "'; ");

            SQLiteDataAdapter prikljucivac = new SQLiteDataAdapter(c);
            DataTable pomocna = new DataTable();

            c.ExecuteNonQuery();


            prikljucivac.Fill(pomocna);

            if (pomocna.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("username zauzet", "ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                box4.SelectAll();
                e.Cancel = true;
            }

            c.Dispose();
            DB.ZatvoriKonekciju();
        }

      
    }
}
