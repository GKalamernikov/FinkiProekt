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
        private static int blankspace(int coordinate)
        {
            int returnvalue = 0;
            if (coordinate < 3)
            {
                returnvalue += 5;
                returnvalue += 3 * (coordinate % 3);
            }
            else if(coordinate >= 3 && coordinate < 6)
            {
                returnvalue += 16;
                returnvalue += 3 * (coordinate % 3);
            }
            else
            {
                returnvalue += 27;
                returnvalue += 3 * (coordinate % 3);
            }
            return returnvalue;
        }

        public void draw(Graphics g, int width, int height)
        {
            Brush br = new SolidBrush(color);
            int sizeX = (int) Math.Round((width - 38) / 9F);
            int sizeY = (int) Math.Round((height - 38) / 9F);
            g.FillRectangle(br,
                (position.X * sizeX) + blankspace(position.X),
                (position.Y * sizeY) + blankspace(position.Y),
                sizeX,
                sizeY);
            br.Dispose();
        }

        public void setPos(Point pos)
        {
            position = pos;
        }
    }
}
