using System;
using System.Drawing;
using System.Windows.Forms;

namespace tomograph
{
    public partial class parallel : Form
    {
        
        public parallel()
        {
            InitializeComponent();
        }
        Graphics g;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
        }
        void draw(int R,int N ,int h ,int M)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            int Xd, Yd, Xi, Yi;//координаты датчиков(d) и источников(i)
            int x = 200+R/2;
            int y = 200+R/2;
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, 200, 200, R, R);//окружность (тело сканирования)
            Pen p1 = new Pen(Color.SkyBlue);
            for (int n = 0; n < N; n++)
            {
                double fi = (Math.PI * n) / N; // угл фи для построения ракурсов
                int mmin = -((M - 1) / 2);//крайний левый номер датчика
                int mmax = (M - 1 )/ 2;// крайний правый
                for (int m = mmin; m <=mmax; m++)
                {
                    Xd = Convert.ToInt32(Math.Round(x + R * Math.Cos(fi)
                   - m * h * Math.Sin(fi)));
                    Yd = Convert.ToInt32(Math.Round(y + R * Math.Sin(fi)
                    + m * h * Math.Cos(fi)));//координаты датчиков
                    Xi = Convert.ToInt32(Math.Round(x - R * Math.Cos(fi)
                    - m * h * Math.Sin(fi)));
                    Yi = Convert.ToInt32(Math.Round(y - R * Math.Sin(fi)
                    + m * h * Math.Cos(fi)));//координаты источников
                    g.DrawLine(p1, Xd, Yd, Xi, Yi);//прямые сканирования
                    
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            int R, N, h, M;
            R = Convert.ToInt32(textBox1.Text);
            N = Convert.ToInt32(textBox2.Text);
            h = Convert.ToInt32(textBox3.Text);
            M = Convert.ToInt32(textBox4.Text);
            draw(R, N, h, M);
        }
    }
}
