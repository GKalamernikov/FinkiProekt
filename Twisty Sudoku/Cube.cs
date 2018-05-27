using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisty_Sudoku
{
    class Cube 
    {
        static Cube theCube;
        Observer cubeWatcher;
        public Sticker[][] matrix { get; private set; }
        Cube(Observer obs)
        {
            cubeWatcher = obs;
            matrix = new Sticker[9][];
            for(int i=0; i<9; i++)
            {
                matrix[i] = new Sticker[9];

            }
            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
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
                    else if(i>=3 && i < 6)
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
        public static Cube getCube(Observer obs)
        {
            if (theCube == null)
            {
                theCube = new Cube(obs);
            }
            return theCube;
        }
        public void draw(Graphics g, int width, int height)
        {
            g.FillRectangle(Brushes.Black, 0, 0, width, height);
            foreach(Sticker[] array in matrix)
            {
                foreach(Sticker sticker in array)
                {
                    sticker.draw(g, width, height);
                }
            }
        }
        public void reset()
        {
            theCube = new Cube(cubeWatcher);
            cubeWatcher.notify();
        }
        
    }
}
