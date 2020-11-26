using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izgled
{
    public partial class FormOpen : Form
    {
        

        public FormOpen()
        {
            InitializeComponent();
            rbtnKomp.Checked = true;
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int igrac = 0;
            if (rbtnCovek.Checked)
                igrac = 2;
            else igrac = 1;
            FormTable ft = new FormTable(igrac);
            ft.ShowDialog();

        }

        private void FormOpen_Load(object sender, EventArgs e)
        {

        }
    }
}
