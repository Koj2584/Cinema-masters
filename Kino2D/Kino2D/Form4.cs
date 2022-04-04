using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino2D
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        private void Vybrat_film(object sender, EventArgs e)
        {
            Form f = new Form3((sender as Button).Text);
            f.Show();
            this.Visible = false;
        }
    }
}
