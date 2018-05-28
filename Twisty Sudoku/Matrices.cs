using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisty_Sudoku
{
    class Matrices
    {
        public static void initialize(Sticker[][] matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i < 3)
                    {
                        if (j < 3)
                        {
                            matrix[i][j] = new Sticker(Color.Yellow, new Point(i, j));
                        }
                        else if (j >= 3 && j < 6)
                        {
                            matrix[i][j] = new Sticker(Color.DarkBlue, new Point(i, j));
                        }
                        else if (j >= 6)
                        {
                            matrix[i][j] = new Sticker(Color.LimeGreen, new Point(i, j));
                        }
                    }
                    else if (i >= 3 && i < 6)
                    {
                        if (j < 3)
                        {
                            matrix[i][j] = new Sticker(Color.DarkRed, new Point(i, j));
                        }
                        else if (j >= 3 && j < 6)
                        {
                            matrix[i][j] = new Sticker(Color.White, new Point(i, j));
                        }
                        else if (j >= 6)
                        {
                            matrix[i][j] = new Sticker(Color.Orange, new Point(i, j));
                        }
                    }
                    else if (i >= 6)
                    {
                        if (j < 3)
                        {
                            matrix[i][j] = new Sticker(Color.SkyBlue, new Point(i, j));
                        }
                        else if (j >= 3 && j < 6)
                        {
                            matrix[i][j] = new Sticker(Color.DarkGreen, new Point(i, j));
                        }
                        else if (j >= 6)
                        {
                            matrix[i][j] = new Sticker(Color.Pink, new Point(i, j));
                        }
                    }
                }
            }
        }
    }
}
