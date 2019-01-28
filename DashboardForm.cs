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
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace Projekt
{
    public partial class DashboardForm : MetroFramework.Forms.MetroForm
    {
        
        public BindingSource bindingSource1 = new BindingSource();
        public List<vozila> vozilal;
        public List<Dashboard> podaci;
        private DataView dv;
        bool showed = false;

     
        public DashboardForm()
        {
            InitializeComponent();


            DataTable dt = new DataTable();

            dt.Columns.Add("Broj Narudzbe");
            dt.Columns.Add("Adresa");
            dt.Columns.Add("Ime");
            dt.Columns.Add("Prezime");
            dt.Columns.Add("IDVozila");
            dt.Columns.Add("Stanje Paketa");

            podaci = Dashboard.DohvatiPodatke();
           
            
            foreach (var a in podaci)
            {
                var row = dt.NewRow();

                row["Broj narudzbe"] = a.IDNarudzbe;
                row["Adresa"] = Convert.ToString(a.adresa);
                row["Ime"] = Convert.ToString(a.ime);
                row["Prezime"] = Convert.ToString(a.prezime);
                row["IDVozila"] = Convert.ToInt32(a.id_vozila);
                row["Stanje Paketa"] = Convert.ToString(a.status_paketa);


                dt.Rows.Add(row);

            }

            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var total = dataGridView1.Rows.Count.ToString();
            metroTextBox1.Text = total.ToString();

        }


        private void ShowMessageBox(string message)
        {
            if (!showed)
                MessageBox.Show(message);
            showed = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            for(int i = dataGridView1.Rows.Count -1; i >= 0; i--)
            {
                
                if(dataGridView1.SelectedRows.Count <1 )
                {
                    ShowMessageBox("Nije odabrana niti jedna narudžba!");
                }
                
                if ((bool)dataGridView1.Rows[i].Cells[0].FormattedValue)
                {
                    ShowMessageBox("Isporuka ove narudžbe je završena");
                   
                    dataGridView1.Rows[i].Cells["Stanje Paketa"].Value = "Isporuceno";
                    
                    dataGridView1.Rows.RemoveAt(i);
                    
                }

            }
                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzbornikDForm nazad = new IzbornikDForm();
            nazad.Show();
            this.Hide();
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("IDVozila = '{0}'", textBox1.Text);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                ShowMessageBox("nije odabrano vozilo");
            }
            else
            {

                vozila.Rasporedi_pakete(textBox1.Text);
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {

                    if ((bool)dataGridView1.Rows[i].Cells[0].FormattedValue)
                    {
                        ShowMessageBox("Paket je dodan u dostavno vozilo");

                        dataGridView1.Rows[i].Cells["Stanje Paketa"].Value = "u tijeku";


                        //dataGridView1.Rows.RemoveAt(i);

                    }

                }
            }
        }
    }
}
