using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Matrices.initialize(matrix);
        }
        public static Cube getCube(Observer obs)
        {
            if (theCube == null)
            {
                theCube = new Cube(obs);
            }
            return theCube;
        }
        public void handleClick(int x, int y)
        {
            foreach (Sticker[] array in matrix)
            {
                foreach (Sticker sticker in array)
                {
                    if(sticker.hit(x, y))
                    {
                        //TO DO: handle click
                    }
                }
            }
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
