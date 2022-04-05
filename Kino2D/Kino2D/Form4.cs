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

        Random r = new Random();
        string[] film = new string[] { "Iron Man", "Neuvěřitelný Hulk", "Iron Man 2", "Thor", "Avengers", "Iron Man 3",
            "Thor: Temný svět","Captain America: První Avenger","Captain America: Návrat prvního Avengera","Strážci Galaxie",
            "Avengers: Age of Ultron","Ant-Man","Captain America: Občanská válka","Doctor Strange","Strážci Galaxie Vol. 2","Spider-Man: Homecoming",
            "Thor: Ragnarok","Black Panther","Avengers: Infinity War","Ant-Man a Wasp","Captain Marvel","Avengers: Endgame",
            "Spider-Man: Daleko od domova" };

        private void Vybrat_film(object sender, EventArgs e)
        {
            Form f = new Form3((sender as Button).Text);
            f.Show();
            this.Visible = false;
        }

        string butF = "";
        private void button5_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as Button).Text == "-")
            {
                string s;
                do
                {
                    int id = r.Next(film.Length);
                    s = film[id];
                } while (butF.IndexOf(s) != -1);
                butF += s;
                (sender as Button).Text = s;
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
