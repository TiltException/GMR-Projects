using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Brick : Sprite
    {
        public Brick(int x, int y, int width, int height, Brush color)
            :base(x, y, width, height, color)
        {            
        }
        public void Draw(System.Drawing.Graphics gfx)
        {
            gfx.FillRectangle(Color, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
