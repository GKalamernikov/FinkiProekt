using System;
using System.Collections.Generic;
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
        Cube()
        {
            matrix = new Sticker[9][];
            for(int i=0; i<9; i++)
            {
                matrix[i] = new Sticker[9];
            }
        }
        static Cube getCube()
        {
            if (theCube == null)
            {
                theCube = new Cube();
            }
            return theCube;
        }
        public void reset()
        {
            theCube = new Cube();
            cubeWatcher.notify();
        }
    }
}
