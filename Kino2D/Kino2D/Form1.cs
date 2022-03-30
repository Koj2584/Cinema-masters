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
        bool[,] sal;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            int x = (int)numericUpDown2.Value;
            int y = (int)numericUpDown1.Value;
            sal = new bool[y, x];
            for (int f = 0; f<y; f++)
            {
                for (int i = 0; i < x; i++)
                {
                  Button b = new Button();
                  b.Width = 30;
                  b.Height = b.Width;
                    if (f ==y-2 && i==x-2 )
                    {
                        b.Location = new Point((b.Width +10) * i, (b.Height + 5) * f);
                        b.Width = 50;
                        b.Text = ((char)((int)'A' + f)).ToString() + i;
                        b.Click += button_Click;
                        b.BackColor = Color.Gray;
                        b.ForeColor = Color.White;
                        panel1.Controls.Add(b);
                        i++;
                    }
                    else
                    {
                        b.Location = new Point((b.Width + 5) * i, (b.Height + 5) * f);
                        b.Text = ((char)((int)'A' + f)).ToString() + i;
                        b.Click += button_Click;
                        b.BackColor = Color.Gray;
                        b.ForeColor = Color.White;
                        panel1.Controls.Add(b);
                    }
                    
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            (sender as Button).BackColor = Color.Red;
           (sender as Button).Image = Properties.Resources.avatar;
        }
    }
}
