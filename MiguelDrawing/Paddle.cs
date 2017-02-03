using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelDrawing
{
    class Paddle
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }
        private Brush Color { get; set; }

        public Paddle(Brush color, int xpos = 30, int ypos = 10, int width = 25, int height = 125, int xspeed = 0, int yspeed = 2)
        {
            if (color != null)
            {
                Color = color;
            }
            else
            {
                Color = Brushes.Black;
            }

            Xpos = xpos;
            Ypos = ypos;
            Width = width;
            Height = height;
            XSpeed = xspeed;
            YSpeed = yspeed;
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Color, Xpos, Ypos, Width, Height);
        }
    }
}
