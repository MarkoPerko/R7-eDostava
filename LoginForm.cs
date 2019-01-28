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
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
       
        public LoginForm()
        {
            InitializeComponent();
        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            RegistracijaForm novi = new RegistracijaForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DB.OtvoriKonekciju();
            SQLiteCommand c = DB.con.CreateCommand();
  
            c.CommandText = ("Select count(*) from Registracija where Username = '" + metroTextBox1.Text + "' and Password = '" + metroTextBox2.Text + "'; ");

            SQLiteDataAdapter prikljucivac = new SQLiteDataAdapter(c);
            DataTable pomocna = new DataTable();

            c.ExecuteNonQuery();
            prikljucivac.Fill(pomocna);


            if (pomocna.Rows[0][0].ToString() == "1")
            {
               
                    IzbornikForm novi = new IzbornikForm();
                    novi.Show();
                    this.Hide();
                


            }
            else
            {
                MessageBox.Show(" Pogresan username ili password");
            }

            c.Dispose();

            DB.ZatvoriKonekciju();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            IzbornikDForm novi = new IzbornikDForm();
            novi.Show();
            this.Hide();

        }
    }
}
