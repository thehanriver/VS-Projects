using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private ArrayList all = new ArrayList();
        private ArrayList first_click = new ArrayList();
        public static Shape shape;
        private int pen_color = 0;
        private int fill_color = 0;
        private int pen_width = 0;
        private int click = 0;
        public Point previous;
        public Form1()
        {
            InitializeComponent();
            this.Text = " Mario Han - Lab 6 ";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            shape = new Shape(pen_color,pen_width);
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            all.Clear();
            panel2.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = all.Count;
            if(count > 0)
            {
                all.RemoveAt(count - 1);
            }
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach(Point point in first_click)
            {
                g.FillEllipse(Brushes.Black, point.X - 5, point.Y - 5, 10, 10);
            }

            if(pen_color != 0 || fill_color != 0) {
                foreach (Shape shape in all)
                {

                    shape.Draw(e.Graphics);

                }
            }

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
           
            if (click == 0)
            {
                first_click.Add(p);
                previous = p;
                click = 1;
                panel2.Invalidate();
            }
            else 
            {
                first_click.Clear();
                if (radioButton1.Checked)
                {
                    if (pen_color == 0 && fill_color == 0)
                        MessageBox.Show("Fill and or pen/outline color must be selected");
                    else
                    {
                        Shape line = new Shape.Line(pen_color, pen_width);
                        line.A = previous;
                        line.B = p;
                        all.Add(line);
                        click = 0;
                    }
                    click = 0;
                }
                else if (radioButton2.Checked)
                {
                    if (pen_color == 0 && fill_color == 0)
                        MessageBox.Show("Fill and or pen/outline color must be selected");
                    else
                    {
                        Shape rect = new Shape.Rectangle(pen_color, fill_color, pen_width);
                        rect.A = previous;
                        rect.B = p;
                        all.Add(rect);
                        click = 0;
                    }
                    click = 0;
                }
                else 
                {
                    if (pen_color == 0 && fill_color == 0)
                        MessageBox.Show("Fill and or pen/outline color must be selected");
                    else
                    {
                        Shape ell = new Shape.Ellipse(pen_color, fill_color, pen_width);
                        ell.A = previous;
                        ell.B = p;
                        all.Add(ell);
                        click = 0;
                    }
                    click = 0;
                }
               
            }
            panel2.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings(pen_color,fill_color,pen_width);
            if(setting.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pen_color = setting.get_pen_color();
                fill_color = setting.get_fill_color();
                pen_width = setting.get_pen_width();
            }
            panel2.Invalidate();
        }
    }
}
