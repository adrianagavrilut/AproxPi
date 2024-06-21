using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AproximarePi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grp;
        Bitmap bmp;
        readonly Random rnd = new Random();
        private int total = 0, inside = 0, radius;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            radius = pictureBox1.Width / 2;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            textBoxPi.Text = $"π: {Math.PI}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            pictureBox1.Image = bmp;
        }

        private void Draw()
        {
            total++;
            int x = rnd.Next(0, 2 * radius);
            int y = rnd.Next(0, 2 * radius);

            double sqrDist = Math.Pow(radius - x, 2) + Math.Pow(radius - y, 2);
            if (sqrDist <= Math.Pow(radius, 2))
            {
                inside++;
                grp.FillEllipse(Brushes.Red, x - 3, y - 3, 7, 7);
            }
            else
                grp.FillEllipse(Brushes.White, x - 3, y - 3, 7, 7);
            textBox1.Text = $"π aprox: {(double)4 * inside / total:F15}";
            pictureBox1.Image = bmp;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            inside = 0;
            total = 0;
            grp.Clear(Color.Black);
            pictureBox1.Image = bmp;
        }
    }
}
