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
    public partial class Form3 : Form
    {   
        bool[,] sal;
        string film;
        public Form3(string nazev)
        {
            InitializeComponent();
            film = nazev;
            label3.Text = film;
            button1_Click(nazev, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            int x = (int)numericUpDown2.Value;
            int y = (int)numericUpDown1.Value;
            sal = new bool[y, x];
            ToolTip t = new ToolTip();
            t.OwnerDraw = true;
            t.Draw += ToolTipDraw;
            //t.P
            t.BackColor = Color.Black;
            t.ForeColor = Color.LightGray;
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
                    b.FlatAppearance.BorderSize = 0;
                    if (((x-4)%3==0&&(i-1)%3==0&&(f==0||f==y-1))|| 
                        ((x - 5) % 3 == 0 && i % 3 == 0 && (f == 0 || f == y - 1))|| 
                        ((x - 3) % 3 == 0 && i % 4 == 0 && (f == 0 || f == y - 1)))
                    {
                        b.Location = new Point((b.Width +5) * i, (b.Height + 5) * f);
                        b.Width = b.Width*2+5;
                        t.SetToolTip(b, ((char)((int)'A' + f)).ToString() + i);
                        b.Click += button_Click;
                        b.BackgroundImage = Properties.Resources.dvojsedadlo;
                        b.BackgroundImageLayout = ImageLayout.Zoom;
                        i++;
                    }
                    else
                    {
                        b.Location = new Point((b.Width + 5) * i, (b.Height + 5) * f);
                        t.SetToolTip(b, ((char)((int)'A' + f)).ToString() + i);
                        b.Click += button_Click;
                    }
                    panel3.Controls.Add(b);
                }
            }
        }

        private void ToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void button_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Chteš si tuto sedačku objednat?\n( pokud si chcete rezervovat klikněte na Ne )", "Objednání", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                (sender as Button).Enabled = false;
                (sender as Button).BackColor = Color.Red;
                (sender as Button).BackgroundImage = Properties.Resources.dvojsedadloobj;
                (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {

                DialogResult result2 = MessageBox.Show("Chteš si tuto sedačku rezervovat?", "Rezervace", MessageBoxButtons.YesNo);
                if (result2 == DialogResult.Yes)
                {
                    // (sender as Button).Enabled = false;
                    (sender as Button).BackColor = Color.Red;
                    (sender as Button).BackgroundImage = Properties.Resources.dvojsedadlorez;
                    (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
                    (sender as Button).Click -= button_Click;
                    (sender as Button).Click += rez_Click;
                }
            }

        }
        private void rez_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show("Chtete zrušit rezervaci?\n", "Zrušení rezervace", MessageBoxButtons.YesNo);
            if (result3 == DialogResult.Yes)
            {
                (sender as Button).BackgroundImage = Properties.Resources.dvojsedadlo;
                (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
                (sender as Button).Click -= rez_Click;
                (sender as Button).Click += button_Click;
            }
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
            if(mouse)
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
