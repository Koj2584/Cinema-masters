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
    public partial class Form1 : Form
    {
        public Form1()
        {

            Form welcome = new Form2();
            welcome.Show();
            welcome.Close();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form4();
            f.Show();
            this.Visible = false;
        }
    }
}
