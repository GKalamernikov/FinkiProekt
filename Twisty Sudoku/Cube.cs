using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twisty_Sudoku
{
    class Cube : Monitor
    {
        static Cube theCube;
        Observer cubeWatcher;
        public Sticker[][] matrix { get; private set; }

        Cube(Observer obs)
        {
            cubeWatcher = obs;
            cubeWatcher.sub(this);
            matrix = new Sticker[9][];
            for(int i=0; i<9; i++)
            {
                matrix[i] = new Sticker[9];
            }
            Matrices.initialize(matrix, cubeWatcher);
        }
        public static Cube getCube(Observer obs)
        {
            if (theCube == null)
            {
                theCube = new Cube(obs);
            }
            return theCube;
        }

        //promenlivi potrebni za handle na mouse move
        Sticker lastClicked;
        int lastX;
        int lastY;  
        public void handleDown(int x, int y)
        {
            foreach (Sticker[] array in matrix)
            {
                foreach (Sticker sticker in array)
                {
                    if(sticker.hit(x, y))
                    {
                        lastClicked = sticker;
                        lastX = x;
                        lastY = y;
                    }
                }
            }
        }

        public void handleUp(int x, int y)
        {
            if(lastClicked.position.X == 0)
                Matrices.isSolved(matrix);
            Sticker target = null ;
            foreach (Sticker[] array in matrix)
            {
                foreach (Sticker sticker in array)
                {
                    sticker.reset();
                    if (sticker.hit(x, y))
                    {
                        target = sticker;
                    }
                }
            }
            if(lastClicked != null && target != null)
                Matrices.makeMove(matrix, lastClicked, target);
            lastClicked = null;
            cubeWatcher.notify();
        }

        public void handleMove(int x, int y)
        {
            if(lastClicked != null)
                lastClicked.move(lastX, lastY, x, y);
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
        public void scramble()
        {
            Random rng = new Random();
            for(int i=0; i<50; i++)
            {
                int row = rng.Next(2);
                int first = rng.Next(9);
                int second = rng.Next(9);
                int third = rng.Next(9);
                if(row == 0)
                {
                    Matrices.makeMove(matrix, matrix[first][second], matrix[first][third]);
                }
                else
                {
                    Matrices.makeMove(matrix, matrix[first][second], matrix[third][second]);
                }
            }
            cubeWatcher.notify();
        }
        public bool isSolved()
        {
            return Matrices.isSolved(matrix);
        }
        public void update()
        {
            if(lastClicked != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    matrix[i][lastClicked.position.Y].offsetX = lastClicked.offsetX;
                    matrix[lastClicked.position.X][i].offsetY = lastClicked.offsetY;
                }
            }
        }
    }
}
