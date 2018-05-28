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
        public Point position { private set; get; } //Pozicija na matricata, ne na ekrano
        private Point upRight;
        private int sizeX;
        private int sizeY;
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
            sizeX = (int) Math.Round((width - 38) / 9F);
            sizeY = (int) Math.Round((height - 38) / 9F);
            upRight = new Point((position.X * sizeX) + blankspace(position.X), (position.Y * sizeY) + blankspace(position.Y));
            g.FillRectangle(br,
                upRight.X,
                upRight.Y,
                sizeX,
                sizeY);
            br.Dispose();
        }
        public bool hit(int x, int y)
        {
            return (((x - upRight.X < sizeX) && (x - upRight.X > 0)) && ((y - upRight.Y < sizeY) && (y - upRight.Y > 0)));
        }
        public void setPos(Point pos)
        {
            position = pos;
        }
    }
}
