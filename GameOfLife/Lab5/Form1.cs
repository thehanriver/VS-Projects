using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {

        const int ROWS = 25;
        const int COLUMNS = 50;
        const int BOX_SIZE = 20;
        private Grid game;
        private Rectangle[,] rect = new Rectangle[25, 50];
        private Point p;
        private bool[,] clicked = new bool[25, 50];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Grid(ROWS, COLUMNS);
            button4.Enabled = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);

            for (int r = 0; r < 25; r++)
            {
                for (int c = 0; c < 50; c++)
                {
                    rect[r, c] = new Rectangle(15 + 20 * c, 60 + 20 * r, 20, 20);
                   
                    if (clicked[r,c])
                    {
                        g.FillRectangle(Brushes.Black, rect[r, c]);
                     
                    } 

                }
            }
            for (int i = 0; i <= 25; i++)
            {
                g.DrawLine(pen, 15, 60 + 20 * i, 1015, 60 + 20 * i);
            }
            for (int j = 0; j <= 50; j++)
            {
                g.DrawLine(pen, 15 + 20 * j, 60, 15 + 20 * j, 560);
            }

            pen.Dispose();
            
          
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
            for (int r = 0; r < 25; r++)
            {
                for (int c = 0; c < 50; c++)
                {
                  
                    if (rect[r, c].Contains(p) )
                    {
                        clicked[r, c] = true;
                        game[r, c] = true;
                    }

                }
            }
            Invalidate();
        }
        //Next Generation
        private void button1_Click(object sender, EventArgs e)
        {
            Grid newg = new Grid(25, 50);
            game.Generate(newg);
            game = newg;
            for (int r = 0; r < 25; r++)
            {
                for (int c = 0; c < 50; c++)
                {
                    if (game[r, c])
                        clicked[r, c] = true;
                    else
                        clicked[r, c] = false;
                }
            }
                    Invalidate();
        }
        //Clear
        private void button2_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < 25; r++)
            {
                for (int c = 0; c < 50; c++)
                {
                    if (clicked[r, c])
                    {
                        game[r, c] = false;
                        clicked[r, c] = false;
                    }
                }
            }
            Invalidate();
        }
        //Start
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
        }
        //Stpo
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Grid newg = new Grid(25, 50);
            game.Generate(newg);
            game = newg;
            for (int r = 0; r < 25; r++)
            {
                for (int c = 0; c < 50; c++)
                {
                    if (game[r, c])
                        clicked[r, c] = true;
                    else
                        clicked[r, c] = false;
                }
            }
            Invalidate();
        }
    }
}
