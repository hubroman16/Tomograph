using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace tomograph
{
    public partial class veer : Form
    {
        public veer()
        {
            InitializeComponent();
        }
        Graphics g;
        bool check = false;


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
        }

        void draw(int R, int N, double alfmax, int M)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);
            int Xd, Yd, Xi, Yi;
            double alfm;//координаты датчиков(d) и источников(i)
            int x = 200 + R / 2;
            int y = 200 + R / 2;
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, 200,200, R, R);//окружность (тело сканирования)
            Pen p1 = new Pen(Color.SkyBlue);
            for (int n = 0; n < N; n++)
            {
                double fi = (2*Math.PI * n) / N; // угл фи для построения ракурсов
                int mmin = -((M - 1) / 2);//крайний левый номер датчика
                int mmax = (M - 1) / 2;// крайний правый
                Xi = Convert.ToInt32(Math.Round(x - R * Math.Cos(fi)));
                Yi = Convert.ToInt32(Math.Round(y - R * Math.Sin(fi)));//координаты источников
                for (int m = mmin; m <= mmax; m++)
                {
                    alfm = ((alfmax*m )/ (M - 1));
                    Xd = Convert.ToInt32(Math.Round(x + R * Math.Cos(fi + 2 * alfm)));
                    Yd = Convert.ToInt32(Math.Round(y + R * Math.Sin(fi + 2 * alfm)));//координаты датчиков
                    g.DrawLine(p1, Xd, Yd, Xi, Yi);//прямые сканирования
                }
            }
            pictureBox2.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            int R, N, alfmax, M;
            R = Convert.ToInt32(textBox8.Text);
            N = Convert.ToInt32(textBox7.Text);
            alfmax = Convert.ToInt32(textBox6.Text);
            M = Convert.ToInt32(textBox5.Text);
            draw(R, N, alfmax * Math.PI / 180, M);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        int R, N, alfmax = 0, M;



        private void timer1_Tick(object sender, EventArgs e)
        {
            R = Convert.ToInt32(textBox8.Text);
            N = Convert.ToInt32(textBox7.Text);
            M = Convert.ToInt32(textBox5.Text);
            g.Clear(Color.Transparent);
            draw(R, N, alfmax * Math.PI / 180, M);
            label10.Text = "Угл: " + alfmax;
            if (alfmax >= 55) { check = true;}
            if (alfmax <= 0) { check = false; }
            if (check) { alfmax -= 5; }
            else { alfmax += 5; };


        }
        
     
    }
}
