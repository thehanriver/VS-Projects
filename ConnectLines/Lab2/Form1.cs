using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = " Mario Han - Lab 2 ";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            const int WIDTH = 20;
            const int HEIGHT = 20;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.Black, 0.01f);

            if (flag == false)
            {
                button1.Text = "Show Lines";
            }
            if (flag == true)
            {
                button1.Text = "Hide Lines";
                for (int i = 0; i < this.coordinates.Count; i++)
                {
                    if (this.coordinates.Count != 1 && (i + 1) < coordinates.Count)
                    {
                        Point a = (Point)coordinates[i];
                        Point b = (Point)coordinates[i + 1];
                        g.DrawLine(pen, a, b);

                    }
                }
            }

            foreach (Point p in this.coordinates)
            {
                g.FillEllipse(Brushes.Red, p.X - WIDTH / 2, p.Y - WIDTH / 2, WIDTH, HEIGHT);
                g.DrawEllipse(pen, p.X - WIDTH / 2, p.Y - WIDTH / 2, WIDTH, HEIGHT);
            }
            pen.Dispose();

        }
        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coordinates.Add(p);
                Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                this.coordinates.Clear();
                Invalidate();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            flag = !flag;
            Invalidate();
        }


    }

}
