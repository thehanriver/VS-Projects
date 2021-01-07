using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
namespace Lab6
{


    public class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public int flag { get; set; }

        public int pen_width;
        public Color pen_color;

        private int WIDTH = 10;
        private int HEIGHT = 10;
        public Shape(int pen_inp, int wid_inp)
        {
            pen_width = wid_inp;
            pen_color = change_pen_color(pen_inp);
        }
        public virtual void Draw(Graphics g)
        {
            if (flag == 1)
            {
                Pen pen = new Pen(Brushes.Black, 0.01f);
                g.FillEllipse(Brushes.Black, A.X - WIDTH / 2, A.Y - WIDTH / 2, WIDTH, HEIGHT);
                g.DrawEllipse(pen, A.X - WIDTH / 2, A.Y - WIDTH / 2, WIDTH, HEIGHT);
                pen.Dispose();
            }
        }
        protected Color change_pen_color(int inp)
        {
            Color c;
            switch (inp)
            {
                case 1:
                    c = Color.FromName("Black");
                    break;
                case 2:
                    c = Color.FromName("Red");
                    break;
                case 3:
                    c = Color.FromName("Blue");
                    break;
                case 4:
                    c = Color.FromName("Green");
                    break;
                default:
                    c = Color.FromName("Black");
                    break;
            }
            return c;
        }
        protected Color change_fill_color(int inp)
        {
            Color c;
            switch (inp)
            {
                case 1:
                    c = Color.FromName("Black");
                    break;
                case 2:
                    c = Color.FromName("Red");
                    break;
                case 3:
                    c = Color.FromName("Blue");
                    break;
                case 4:
                    c = Color.FromName("Green");
                    break;
                default:
                    c = Color.FromName("clear");
                    break;
            }
            return c;
        }
        public class Line: Shape
        { 
            public Point point_1;
            public Point point_2;
            public Line(int pen_inp, int wid_inp) : base(pen_inp, wid_inp)
            {
                point_1 = A;
                point_2 = B;
            }
            override public void Draw(Graphics g)
            {
                point_1 = A;
                point_2 = B;
                Pen pen = new Pen(pen_color, pen_width);
                g.DrawLine(pen, point_1, point_2);
                pen.Dispose();
            }
        }
        public class Rectangle : Shape
        {
            public Point point_1;
            public Point point_2;
            public int width,height,x,y;
            private Color fill;
            public Rectangle(int pen_inp,int fill_inp, int wid_inp) : base(pen_inp, wid_inp)
            {
                point_1 = A;
                point_2 = B;
                fill = change_fill_color(fill_inp);
            }
            override public void Draw(Graphics g)
            {
                point_1 = A;
                point_2 = B;
                if (point_1.X <= point_2.X)
                { x = point_1.X; }
                else
                { x = point_2.X; }

                if (point_1.Y <= point_2.Y)
                { y = point_1.Y; }
                else
                { y = point_2.Y; }

                width = Math.Abs(point_1.X - point_2.X);
                height = Math.Abs(point_1.Y - point_2.Y);
                Pen pen = new Pen(pen_color, pen_width);
                Brush fill_up = new SolidBrush(fill);
                g.FillRectangle(fill_up, x, y, width, height);
                g.DrawRectangle(pen, x, y, width, height);
                pen.Dispose();
            }
        }
        public class Ellipse : Shape
        {
            public Point point_1;
            public Point point_2;
            public int width, height, x, y;
            private Color fill;
            public Ellipse(int pen_inp, int fill_inp, int wid_inp) : base(pen_inp, wid_inp)
            {
                point_1 = A;
                point_2 = B;
                fill = change_fill_color(fill_inp);
            }
           
            override public void Draw(Graphics g)
            {
                point_1 = A;
                point_2 = B;
                if (point_1.X <= point_2.X)
                { x = point_1.X; }
                else
                { x = point_2.X; }

                if (point_1.Y <= point_2.Y)
                { y = point_1.Y; }
                else
                { y = point_2.Y; }

                width = Math.Abs(point_1.X - point_2.X);
                height = Math.Abs(point_1.Y - point_2.Y);
                Pen pen = new Pen(pen_color, pen_width);
                Brush fill_up = new SolidBrush(fill);
                g.FillEllipse(fill_up, x, y, width, height);
                g.DrawEllipse(pen, x, y, width, height);
                pen.Dispose();
            }
        }
    }
}
