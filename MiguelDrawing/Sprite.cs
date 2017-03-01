using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelDrawing
{
    public class Sprite
    {
        private Rectangle HitBox
        {
            get
            {
                return new Rectangle(Position, size);
            }
        }

        public Point Position { get; set; }
        public Point Speed { get; set; }

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

        private Size size;

        private Brush color;


        public Sprite(int x = 0, int y = 0, int xSpeed = 0, int ySpeed = 0, int height = 1, int width = 1, Brush color = null)
            : this(new Point(x, y), new Point(xSpeed, ySpeed), new Size(height, width), color)
        {
        }
        public Sprite(Point position, Point speed, Size size, Brush color)
        {
            Position = position;
            Speed = speed;
            this.size = size;
            this.color = color;
        }
    }
}
