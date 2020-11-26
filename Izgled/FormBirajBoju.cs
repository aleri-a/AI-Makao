using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIG.AV.Karte;

namespace Izgled
{
    public partial class FormBirajBoju : Form
    {
       public  Boja Boja { get; set; }
       public  bool kraj = false;
        private FormTable tabla;

        public FormBirajBoju(FormTable tab)
        {
            InitializeComponent();
            tabla = tab;
            
        }

        private void btnPik_Click(object sender, EventArgs e)
        {
            Boja = Boja.Pik;
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
        }

        private void btnHerc_Click(object sender, EventArgs e)
        {
            Boja = Boja.Herz;
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
        }

        private void btnTref_Click(object sender, EventArgs e)
        {
            Boja = Boja.Tref;
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
        }

        private void btnKaro_Click(object sender, EventArgs e)
        {
            Boja = Boja.Karo;
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            kraj = true;
            tabla.PomocnaKarta.Boja = Boja;
            this.Close();
           
        }

        private void FormBirajBoju_Load(object sender, EventArgs e)
        {

        }
    }
}
