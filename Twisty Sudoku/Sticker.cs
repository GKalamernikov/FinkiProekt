using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisty_Sudoku
{
    class Sticker
    {
        Color color;
        Point position; //Pozicija na matricata, ne na ekrano
        public Sticker(Color c, Point p)
        {
            position = p;
            color = c;
        }

        public void draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void setPos(Point pos)
        {
            position = pos;
        }
    }
}
