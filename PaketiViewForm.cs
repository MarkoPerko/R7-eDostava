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
    public partial class PaketiViewForm : MetroFramework.Forms.MetroForm
    {
        public PaketiViewForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DB.OtvoriKonekciju();
            SQLiteDataAdapter sqlDa = new SQLiteDataAdapter("SELECT * FROM Paket ", DB.con);
            DataTable pomocna = new DataTable();
            sqlDa.Fill(pomocna);
            dataGridView1.DataSource = pomocna;
            DB.ZatvoriKonekciju();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            IzbornikDForm novi = new IzbornikDForm();
            novi.Show();
            this.Hide();
        }
    }
}
