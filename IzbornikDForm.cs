using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class IzbornikDForm : MetroFramework.Forms.MetroForm
    {
        public IzbornikDForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            NarudzbaViewForm novi = new NarudzbaViewForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            PaketiViewForm novi = new PaketiViewForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DashboardForm novi = new DashboardForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            VozilaViewForm novi = new VozilaViewForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            LoginForm novi = new LoginForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            VozilaForm vozila = new VozilaForm();
            vozila.Show();
            this.Hide();
        }
    }
}
