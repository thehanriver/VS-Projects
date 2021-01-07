using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab5
{
    class Grid
    {
        private bool[,] board; 
        private int my_rows, my_columns;
       
        //set up initial grid
        //Grid current = new Grid(cols, rows);
        //get next generation
        //Grid newg = new Grid(cols, rows);
        //current.Generate(newg);
        //save as current
        //current = newg;
        //the old grid will be garbage collected eventually
        public Grid( int rows, int columns)
        {
            my_rows = rows;
            my_columns = columns;

            board = new bool[my_rows, my_columns];

            for(int r = 0; r < 25; r++)
            {
                for(int c = 0; c < 50; c++)
                {
                    board[r,c] = false;
                }
            }
        }
        public bool this[int i, int j]
        {
            get => board[i, j];
            set => board[i, j] = value;
        }
       public void Generate(Grid g)
        {
            
            for (int r = 0; r <= 25; r++)
            {
                
                for (int c = 0; c <= 50; c++)
                {
                    
                    if (r - 1 >= 0 && c - 1 >= 0 && c + 1 < 50 && r + 1 <25)
                    {
                        int neigh = 0;
                        if (board[r - 1, c]) neigh++;
                        if (board[r + 1, c]) neigh++;
                        if (board[r, c + 1]) neigh++;
                        if (board[r, c - 1]) neigh++;
                        if (board[r + 1, c - 1]) neigh++;
                        if (board[r - 1, c + 1]) neigh++;
                        if (board[r + 1, c + 1]) neigh++;
                        if (board[r - 1, c - 1]) neigh++;

                        if (board[r, c] && neigh == 2) g[r, c] = true;
                       
                        else
                            g[r, c] = false;
                        if (neigh == 3) g[r, c] = true;


                    }
                }
            }
        }
    }
}
