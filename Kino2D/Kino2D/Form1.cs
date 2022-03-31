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
            Form2 f2=new Form2();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Show();
            Task.Delay(5000).Wait();
            f2.Close();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            int x = (int)numericUpDown2.Value;
            int y = (int)numericUpDown1.Value;
            sal = new bool[y, x];
            ToolTip t = new ToolTip();
            for (int f = 0; f<y; f++)
            {
                for (int i = 0; i < x; i++)
                {
                    Button b = new Button();
                    b.Width = 30;
                    b.Height = b.Width;
                    b.BackColor = panel1.BackColor;
                    b.BackgroundImage = Properties.Resources.sedadlo;
                    b.BackgroundImageLayout = ImageLayout.Zoom;
                    b.FlatStyle = FlatStyle.Flat;
                    b.ForeColor = Color.White;
                    if ((x%2==0&&x%3==0&&i%4==0&&(f==0||f==y-1))||(x % 2 != 0 && i % 3 == 0&& (f == 0 || f == y - 1)))
                    {
                        b.Location = new Point((b.Width +5) * i, (b.Height + 5) * f);
                        b.Width = b.Width*2+5;
                        t.SetToolTip(b, ((char)((int)'A' + f)).ToString() + i);
                        b.Click += button_Click;
                        b.BackgroundImage = Properties.Resources.dvojsedadlo;
                        b.BackgroundImageLayout = ImageLayout.Zoom;
                        panel1.Controls.Add(b);
                        i++;
                    }
                    else
                    {
                        b.Location = new Point((b.Width + 5) * i, (b.Height + 5) * f);
                        t.SetToolTip(b, ((char)((int)'A' + f)).ToString() + i);
                        b.Click += button_Click;
                        panel1.Controls.Add(b);
                    }
                    
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            (sender as Button).BackColor = Color.Red;
            (sender as Button).BackgroundImage = Properties.Resources.avatar;
            (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
