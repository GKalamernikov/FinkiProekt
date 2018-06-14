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
        Observer cubeWatcher;
        public Point position { set; get; } //Pozicija na matricata, ne na ekrano
        public int offsetX { set; get; }
        public int offsetY { set; get; }
        private Point upRight;
        private int sizeX;
        private int sizeY;
        
        public Sticker(Color c, Point p, Observer w)
        {
            position = p;
            color = c;
            cubeWatcher = w;
            offsetX = 0;
            offsetY = 0;
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

            int posX = (upRight.X + offsetX);
            if (posX < 0)
            {
                posX += width;
            }
            posX %= width;
            int posY = (upRight.Y + offsetY);
            if (posY < 0)
            {
                posY += height;
            }
            posY %= height;
            g.FillRectangle(br, posX, posY, sizeX, sizeY);

            if (posX + sizeX > width)
            {
                g.FillRectangle(br, 0, posY, (posX + sizeX) - width, sizeY);
            }
            if (posY + sizeY > width)
            {
                g.FillRectangle(br, posX, 0, sizeX, (posY + sizeY) - height);
            }
            br.Dispose();
        }
        public bool hit(int x, int y)
        {
            return (((x - upRight.X < sizeX) && (x - upRight.X > 0)) && ((y - upRight.Y < sizeY) && (y - upRight.Y > 0)));
        }
        public void move(int fromX, int fromY, int x, int y)
        {
            int tmpOffsetX = x - fromX;
            int tmpOffsetY = y - fromY;
            if(Math.Abs(tmpOffsetX) > Math.Abs(tmpOffsetY))
            {
                offsetX = tmpOffsetX;
                offsetY = 0;
            }
            else
            {
                offsetY = tmpOffsetY;
                offsetX = 0;
            }
            cubeWatcher.notify();
        }
        public void reset()
        {
            offsetX = 0;
            offsetY = 0;
        }
        public void debug()
        {
            color = Color.Magenta;
        }
    }
}
