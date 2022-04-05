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
            "Thor: Ragnarok","Black Panther" };

        private void Vybrat_film(object sender, EventArgs e)
        {
            Form f = new Form3((sender as Button).Text);
            f.Show();
            this.Visible = false;
        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            (sender as Button).Text = film[r.Next(film.Length)];
        }
    }
}
