using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelDrawing
{
    class Paddle : MovingSprite
    {
        public Paddle(int x, int y, int width, int height, int xSpeed, int ySpeed, Brush color)
            : base(new Point(x, y), new Size(width, height), color, new Point(xSpeed, ySpeed))
        {
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Color, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
