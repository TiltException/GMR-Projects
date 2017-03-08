using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelDrawing
{
    public class Ball : MovingSprite
    {
        public Ball(int x, int y, int diameter, Brush color, int xSpeed, int ySpeed)
            : this(new Point(x, y), new Size(diameter, diameter), color, new Point(xSpeed, ySpeed))
        {
            //Pass-through ctor
        }

       
        public Ball(Point position, Size diameter, Brush color, Point speed)
            : base(position, diameter, color, speed)
        {

        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Color, Position.X, Position.Y, Size.Width, Size.Height);
        }

        //public void Draw(Graphics gfx)
        //{     
        //    gfx.FillEllipse(color, Position.X, Position.Y, Diameter, Diameter);
        //}

    }
}
