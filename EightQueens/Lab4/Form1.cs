using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        string Q = "Q";
        int flag = 0;
        const int squareSize = 50;
        const int grid = 7;
        //This is a field in your form class
        private bool[,] board = new bool[8, 8];
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font myFont = new Font("Arial", 30 , FontStyle.Bold);
            Pen blackPen = new Pen(Color.Black, 3);
            //box 
            g.DrawRectangle( blackPen, 100, 100, 400, 400);
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        if (i < 8 && j < 8)
                        {
                            g.FillRectangle(Brushes.Black, 100 + 50 * i, 100 + 50 * j, 50, 50);
                            if(flag == 1 && board[i, j])
                            {
                                g.DrawString(Q, myFont, Brushes.White, 100 + 50 * i, 100 + 50 * j);//centered Q for black squares
                            }
                        }
                    }
                    else
                    {
                        if (i < 8 && j < 8)
                        {
                            g.FillRectangle(Brushes.White, 100 + 50 * i, 100 + 50 * j, 50, 50);
                            if (flag == 1 && board[i, j])
                            {
                                g.DrawString(Q, myFont, Brushes.Black, 100 + 50 * i, 100 + 50 * j);//centered Q for black squares
                            }
                        }
                    }
                }
            }
            //flag = 0;
            blackPen.Dispose();
        }
        private bool IsSafe(int col, int row)
        {
            for (int c = col, r = row; c >= 0 && r >= 0; c--, r--)
            {
                if (board[c, r])
                {
                    return false;
                }
            }
            for (int c = col, r = row; c >= 0 && r < 8; c--, r++)
            {
                if (board[c, r])
                {
                    return false;
                }
            }
            for (int c = col, r = row; c < 8 && r >= 0; c++, r--)
            {
                if (board[c, r])
                {
                    return false;
                }
            }
            for (int c = col, r = row; c < 8 && r < 8; c++, r++)
            {
                if (board[c, r])
                {
                    return false;
                }
            }
            for (int j = 0; j < 8; j++)
            {
                if (board[j, row])
                {
                    return false;
                }
            }
            for (int j = 0; j < 8; j++)
            {
                if (board[col, j])
                {
                    return false;
                }
            }
            return true;

        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            flag = 1;
            int row = 0;
            board = new bool[8, 8]; //clear board]
                                    //Set row in column 0 from selected radio button
                                    //row = radio
            row = checkButton();
            board[0, row] = true;
            PlaceQueen(1);  //start at column 1
        
            Invalidate();   //draw board
        }
        private bool PlaceQueen(int col)
        {
            for (int row = 0; row <= 7; ++row)
            {
                if (IsSafe(col, row))
                {
                    board[col, row] = true; //place queen

                    if (col == 7)
                        return true;    //we have a solution
                    else
                    {
                        if (PlaceQueen(col + 1))    //continue to next column
                            return true;
                        else
                            board[col, row] = false;   //retract move and look for another safe square
                    }
                }
            }
            return false;   //no safe columns left so backtrack
        }

        private int checkButton()
        {
           
                if (radioButton2.Checked) return 0;
                else if (radioButton1.Checked) return 1;
                else if (radioButton3.Checked) return 2;
                else if (radioButton4.Checked) return 3;
                else if (radioButton5.Checked) return 4;
                else if (radioButton6.Checked) return 5;
                else if (radioButton7.Checked) return 6;
                else if (radioButton8.Checked) return 7;
                else return 0;
         
        }
    }
}
