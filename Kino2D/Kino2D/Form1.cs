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
        private void Close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minim(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        bool max = false;
        private void Maxim(object sender, EventArgs e)
        {
            max = !max;
            if (max)
            {
                WindowState = FormWindowState.Maximized;
                (sender as Button).Text = "🗗";
            }
            else
            {
                WindowState = FormWindowState.Normal;
                (sender as Button).Text = "🗖";
            }
        }

        bool mouse = false;
        Point mousePos;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (!max)
            {
                mousePos.X = e.X;
                mousePos.Y = e.Y;
                mouse = true;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse)
            {
                Point point = PointToScreen(e.Location);
                Location = new Point(point.X - mousePos.X, point.Y - mousePos.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }
    }
}
