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
        private static void cycleRow(Sticker[][] matrix, int row, int amount)
        {
            Sticker[] tmpRow = new Sticker[9];
            for(int i=0; i<9; i++)
            {
                tmpRow[i] = matrix[i][row];
                //matrix[i][row].debug();
            }
            for (int i = 0; i < 9; i++)
            {
                matrix[(i + amount) % 9][row] = tmpRow[i];
                matrix[(i + amount) % 9][row].position = new Point((i + amount) % 9, row);
            }
        }
        private static void cycleColumn(Sticker[][] matrix, int column, int amount)
        {
            Sticker[] tmpRow = new Sticker[9];
            for (int i = 0; i < 9; i++)
            {
                tmpRow[i] = matrix[column][i];
                //matrix[i][row].debug();
            }
            for (int i = 0; i < 9; i++)
            {
                matrix[column][(i + amount) % 9] = tmpRow[i];
                matrix[column][(i + amount) % 9].position = new Point(column, (i + amount) % 9);
            }
        }
        public static void makeMove(Sticker[][] matrix, Sticker source, Sticker target)
        {
            if(source.position.X == target.position.X)
            {
                cycleColumn(matrix, source.position.X, (target.position.Y - source.position.Y + 9) % 9);
            }
            else if (source.position.Y == target.position.Y)
            {
                cycleRow(matrix, source.position.Y, (target.position.X - source.position.X + 9) % 9);
            }
        }
        public static void initialize(Sticker[][] matrix, Observer o)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i < 3)
                    {
                        if (j < 3)
                        {
                            matrix[i][j] = new Sticker(Color.Yellow, new Point(i, j), o);
                        }
                        else if (j >= 3 && j < 6)
                        {
                            matrix[i][j] = new Sticker(Color.DarkBlue, new Point(i, j), o);
                        }
                        else if (j >= 6)
                        {
                            matrix[i][j] = new Sticker(Color.LimeGreen, new Point(i, j), o);
                        }
                    }
                    else if (i >= 3 && i < 6)
                    {
                        if (j < 3)
                        {
                            matrix[i][j] = new Sticker(Color.DarkRed, new Point(i, j), o);
                        }
                        else if (j >= 3 && j < 6)
                        {
                            matrix[i][j] = new Sticker(Color.White, new Point(i, j), o);
                        }
                        else if (j >= 6)
                        {
                            matrix[i][j] = new Sticker(Color.Orange, new Point(i, j), o);
                        }
                    }
                    else if (i >= 6)
                    {
                        if (j < 3)
                        {
                            matrix[i][j] = new Sticker(Color.SkyBlue, new Point(i, j), o);
                        }
                        else if (j >= 3 && j < 6)
                        {
                            matrix[i][j] = new Sticker(Color.DarkGreen, new Point(i, j), o);
                        }
                        else if (j >= 6)
                        {
                            matrix[i][j] = new Sticker(Color.Pink, new Point(i, j), o);
                        }
                    }
                }
            }
        }
    }
}
