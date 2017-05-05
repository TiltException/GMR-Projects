using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelSnakeGame
{
    public class SnakePiece
    {
        private const int defaultSize = 50;
        public System.Drawing.Point Position { get; set;}
        public System.Drawing.Size Size { get; set; }
        public System.Drawing.Brush Color { get; set; }

        public SnakePiece(int x, int y, System.Drawing.Brush color = null)
            :   this(new System.Drawing.Point(x,y), color)
        {
        }
        public SnakePiece(System.Drawing.Point point, System.Drawing.Brush color = null)
        {
            Position = point;
            Size = new System.Drawing.Size(defaultSize,defaultSize);
            if (color == null)
            {
                Color = System.Drawing.Brushes.Green;
            }
            else
            {
                Color = color;
            }
        }

        public void Draw(System.Drawing.Graphics gfx)
        {
            gfx.DrawRectangle(System.Drawing.Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            gfx.FillRectangle(Color, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
