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
    public partial class IzbornikForm : MetroFramework.Forms.MetroForm
    {
        public IzbornikForm()
        {
            InitializeComponent();
        }

      

     

      

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DodajNForm novi = new DodajNForm();
            novi.Show();
            this.Hide();
        }

       

        private void metroButton4_Click(object sender, EventArgs e)
        {
            IzmijeniPForm novi = new IzmijeniPForm();
            novi.Show();
            this.Hide();

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            LoginForm novi = new LoginForm();
            novi.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            IzmijeniNForm novi = new IzmijeniNForm();
            novi.Show();
            this.Hide();
        }
    }
}
