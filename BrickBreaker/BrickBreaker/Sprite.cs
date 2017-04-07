using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Sprite
    {
        private Rectangle HitBox
        {
            get
            {
                return new Rectangle(Position, Size);
            }
        }

        public Point Position { get; set; }

        #region alternativeImplementation
        //public int X
        //{
        //    get
        //    {
        //        return Position.X;
        //    }
        //    set
        //    {
        //        Position = new Point(value, Position.Y);
        //    }
        //}

        //public int Y
        //{
        //    get
        //    {
        //        return Position.Y;
        //    }
        //    set
        //    {
        //        Position = new Point(Position.X, value);
        //    }
        //}
        #endregion alternativeImplementation

        public Size Size;

        public Brush Color;


        public Sprite(int x = 0, int y = 0, int width = 1, int height = 1, Brush color = null)
            : this(new Point(x,y), new Size(width, height), color)
        {
        }

        public Sprite(Point position, Size size, Brush color)
        {
            Position = position;
            Size = size;
            if (color == null)
            {
                Color = Brushes.Black;
            }
            else
            {
                Color = color;
            }
        }

        public bool isIntersectingLeftRight(Sprite sprite)
        {
            Rectangle leftBound = new Rectangle(sprite.Position.X, sprite.Position.Y, 0, sprite.Size.Height);
            Rectangle rightBound = new Rectangle(sprite.Position.X + sprite.Size.Width, sprite.Position.Y, 0, sprite.Size.Height);

            return HitBox.IntersectsWith(leftBound) || HitBox.IntersectsWith(rightBound);
        }

        public bool isIntersectingTopBot(Sprite sprite)
        {
            Rectangle topBound = new Rectangle(sprite.Position.X, sprite.Position.Y, sprite.Size.Width, 0);
            Rectangle bottomBound = new Rectangle(sprite.Position.X, sprite.Position.Y + sprite.Size.Height, sprite.Size.Width, 0);

            return HitBox.IntersectsWith(topBound) || HitBox.IntersectsWith(bottomBound);
        }
    }
}
