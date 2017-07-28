using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelSnakeGame
{
    public enum Direction
    {
        Up, Down, Left, Right
    };
    public class SnakePiece
    {
        public static int defaultSize = 50;
        public System.Drawing.Point Position { get; set;}
        public System.Drawing.Size Size { get; set; }
        public System.Drawing.Brush Color { get; set; }
        public Direction direction;

        public SnakePiece(int x, int y, System.Drawing.Brush color = null, Direction dir = Direction.Right)
            :   this(new System.Drawing.Point(x,y), color, dir)
        {
        }
        public SnakePiece(System.Drawing.Point point, System.Drawing.Brush color = null, Direction dir = Direction.Right)
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

            direction = dir;
        }
        
        public void Draw(System.Drawing.Graphics gfx)
        {
            gfx.DrawRectangle(System.Drawing.Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            gfx.FillRectangle(Color, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
