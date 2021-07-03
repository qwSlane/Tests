using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_Set
{
    public partial class Form1 : Form
    {
        const int MAX_ITERATIONS = 1000;

        Bitmap bmp;
        double hx = 0, hy = 0, ix, iy, n = 0;
        double SizeArea, ScaleArea;
        Size size;
        Color col;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.MouseWheel += new MouseEventHandler(p1_Wheel);
            pictureBox1.Image = bmp;
            size = pictureBox1.Size;

            SizeArea = 3;
            ScaleArea = 3;

        }

        void p1_Wheel(object sender, MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;
            if (e.Delta > 0)
            {
                hx = (hx - SizeArea / 2) + X * (SizeArea / size.Width);
                hy = (hy - SizeArea / 2) + Y * (SizeArea / size.Height);
                SizeArea /= ScaleArea;
                Draw();
            }
            else
            {
                ix = (hx - SizeArea / 2) + X * (SizeArea / size.Width);
                iy = (hy - SizeArea / 2) + Y * (SizeArea / size.Height);
                SizeArea *= ScaleArea;
                Draw();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
        }
        public void Draw()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            size = pictureBox1.Size;


            for (int x = 0; x < size.Width; x++)
            {
                ix = (hx - SizeArea / 2) + x * (SizeArea / size.Width);
                for (int y = 0; y < size.Height; y++)
                {
                    iy = (hy - SizeArea / 2) + y * (SizeArea / size.Height);
                    Complex zero = new Complex(0, 0);
                    int i = 0;
                    do
                    {
                        i++;
                        zero.Sqr();
                        zero.Add(new Complex(ix, iy));
                        if (zero.Vect() > 2) break;
                    }
                    while (i < MAX_ITERATIONS);

                    col = Setcol(i);
                    bmp.SetPixel(x, y, col);
                }
                pictureBox1.Image = bmp;
            }
        }


        Color Setcol(int n)
        {
            if (n < MAX_ITERATIONS && n > 0)
            {
                int i = n % 16;
                Color[] mapping = new Color[16];

                mapping[0] = Color.FromArgb(66, 30, 15);
                mapping[1] = Color.FromArgb(25, 7, 26);
                mapping[2] = Color.FromArgb(9, 1, 47);
                mapping[3] = Color.FromArgb(4, 4, 73);
                mapping[4] = Color.FromArgb(0, 7, 100);
                mapping[5] = Color.FromArgb(12, 44, 138);
                mapping[6] = Color.FromArgb(24, 82, 177);
                mapping[7] = Color.FromArgb(57, 125, 209);
                mapping[8] = Color.FromArgb(134, 181, 229);
                mapping[9] = Color.FromArgb(211, 236, 248);
                mapping[10] = Color.FromArgb(241, 233, 191);
                mapping[11] = Color.FromArgb(248, 201, 95);
                mapping[12] = Color.FromArgb(255, 170, 0);
                mapping[13] = Color.FromArgb(204, 128, 0);
                mapping[14] = Color.FromArgb(153, 87, 0);
                mapping[15] = Color.FromArgb(106, 52, 3);
                return mapping[i];
            }
            else return Color.Black;
        }
    }
}
