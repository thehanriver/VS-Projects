using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public partial class Engine
    {
        private bool[,] isTaken = new bool[3, 3];
  
        public Engine()
        {
        }
        public void restart()
        {
            isTaken = new bool[3, 3];
        }
        public void killBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    isTaken[i, j] = true;
                }
            }
        }
        public int EndCheck(Form1.CellSelection[,] grid)
        {
            int Xcount = 0;
            int Ocount = 0;
            int Xwins = 1;
            int Owins = 2;
            int tie = 0;
            int playon = 4;
            //Columns
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == Form1.CellSelection.X)
                        Xcount++;
                    else if (grid[i, j] == Form1.CellSelection.O)
                        Ocount++;
                    if (Xcount == 3)
                        return Xwins;
                    if (Ocount == 3)
                        return Owins;
                }
                Xcount = 0;
                Ocount = 0;
            }
            Xcount = 0;
            Ocount = 0;
            //rows
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[j, i] == Form1.CellSelection.X)
                        Xcount++;
                    else if (grid[j, i] == Form1.CellSelection.O)
                        Ocount++;
                    if (Xcount == 3)
                        return Xwins;
                    if (Ocount == 3)
                        return Owins;
                }
                Xcount = 0;
                Ocount = 0;
            }
            Xcount = 0;
            Ocount = 0;
            //Crosses
            for (int i = 0, j = 0; i < 3; i++, j++)
            {
                if (grid[i, j] == Form1.CellSelection.X)
                    Xcount++;
                else if (grid[i, j] == Form1.CellSelection.O)
                    Ocount++;
                if (Xcount == 3)
                    return Xwins;
                if (Ocount == 3)
                    return Owins;
            }
            Xcount = 0;
            Ocount = 0;
            for (int i = 0, j = 2; i < 3; i++, j--)
            {
                if (grid[i, j] == Form1.CellSelection.X)
                    Xcount++;
                else if (grid[i, j] == Form1.CellSelection.O)
                    Ocount++;
                if (Xcount == 3)
                    return Xwins;
                if (Ocount == 3)
                    return Owins;
            }
            Xcount = 0;
            Ocount = 0;
            //Tie check
            tie = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   if(isTaken[i, j])
                        tie++;
                }
            }
            if(tie >= 9)
            {
                return 9;
            }
            else
            {
                return playon;
            }
        }
        public (int,int) Computer(Form1.CellSelection[,] grid)
        {
            int k = 0;
            int j = 0;
            bool success = false;
            (int, int) nextMove = (0, 0);

            //random selection
            for (k = 0; k <= 2; k++)
            {
                for (j = 0; j <= 2; j++)
                {
                    if (isTaken[k, j] != true)
                    {
                        nextMove = (k, j);
                        isTaken[k, j] = true;
                        success = true;
                        break;
                    }
                    else continue;

                }
                if (success == true)
                    break;
                else continue;
            }

            nextMove = WinSaveCheck(grid, nextMove);

            if(isTaken[1,1] != true)
            {
                nextMove = (1, 1);
                isTaken[k, j] = true;
            }

            return nextMove;
        }
        public void updateTaken(Form1.CellSelection[,] grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++){
                    if (grid[i, j] != Form1.CellSelection.N)
                    {
                        isTaken[i, j] = true;
                    } 
                }
            }
        }

        private (int,int) WinSaveCheck(Form1.CellSelection[,] grid, (int, int) move)
        {
            (int, int) nextMove = move;
            int m = 0;
            int n = 0;
            int Xcount = 0;
            int Ocount = 0;
            bool SorW = false;
            //winning/Saving move check
            //Columms
            for (m = 0; m < 3; m++)
            {
                for (n = 0; n < 3; n++)
                {
                    if (grid[m, n] == Form1.CellSelection.O)
                    {
                        Ocount++;
                        if (Ocount == 2 && Xcount == 0)
                        {
                            SorW = true;
                            break;
                        }
                    }

                    if (grid[m, n] == Form1.CellSelection.X)
                    {
                        Xcount++;
                        if (Xcount == 2 && Ocount == 0)
                        {
                            SorW = true;
                            break;
                        }
                    }
                }
                if (SorW == true)
                    break;
                Xcount = 0;
                Ocount = 0;
            }
            if (m < 3)
            {
                for (int p = 0; p < 3; p++)
                {
                    if (grid[m, p] == Form1.CellSelection.N)
                    {
                        nextMove = (m, p);
                        isTaken[m, p] = true;
                    }
                }
            }
            //rows
            Xcount = 0;
            Ocount = 0;
            SorW = false;
            for (m = 0; m < 3; m++)
            {
                for (n = 0; n < 3; n++)
                {
                    if (grid[n, m] == Form1.CellSelection.O)
                    {
                        Ocount++;
                        if (Ocount == 2)
                        {
                            SorW = true;
                            break;
                        }
                    }

                    if (grid[n, m] == Form1.CellSelection.X)
                    {
                        Xcount++;
                        if (Xcount == 2)
                        {
                            SorW = true;
                            break;
                        }
                    }
                }
                if (SorW == true)
                    break;
                Xcount = 0;
                Ocount = 0;
            }
            if (m < 3)
            {
                for (int p = 0; p < 3; p++)
                {
                    if (grid[p, m] == Form1.CellSelection.N)
                    {
                        nextMove = (p, m);
                        isTaken[p, m] = true;
                    }
                }
            }
            //crosses
            Xcount = 0;
            Ocount = 0;
            SorW = false;
            for (m = 0, n = 2; m < 3; m++, n--)
            {
                if (grid[m, n] == Form1.CellSelection.O)
                {
                    Ocount++;
                    if (Ocount == 2)
                    {
                        SorW = true;
                        break;
                    }
                }

                if (grid[m, n] == Form1.CellSelection.X)
                {
                    Xcount++;
                    if (Xcount == 2)
                    {
                        SorW = true;
                        break;
                    }
                }
            }
            if (m < 3)
            {
                for (int p = 0, q = 2; p < 3; p++, q--)
                {
                    if (grid[p, q] == Form1.CellSelection.N)
                    {
                        nextMove = (p, q);
                        isTaken[p, q] = true;
                    }
                }
            }
            Xcount = 0;
            Ocount = 0;
            for (m = 0, n = 0; m < 3; m++, n++)
            {
                if (grid[m, n] == Form1.CellSelection.O)
                {
                    Ocount++;
                    if (Ocount == 2)
                    {
                        SorW = true;
                        break;
                    }
                }

                if (grid[m, n] == Form1.CellSelection.X)
                {
                    Xcount++;
                    if (Xcount == 2)
                    {
                        SorW = true;
                        break;
                    }
                }
            }
            if (m < 3)
            {
                for (int p = 0, q = 0; p < 3; p++, q++)
                {
                    if (grid[p, q] == Form1.CellSelection.N)
                    {
                        nextMove = (p, q);
                        isTaken[p, q] = true;
                    }

                }
            }
            //reset
            Xcount = 0;
            Ocount = 0;
            SorW = false;
            return nextMove;

        }
    }
}

