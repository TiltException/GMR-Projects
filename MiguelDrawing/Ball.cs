using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelDrawing
{
    public class Ball
    {
        public Point Position { get; set; }
        public Point Speed { get; set; }
        
        public int Diameter { get; set; }

        private Brush color;

        public Ball(int x, int y, int diameter, Brush color, int xSpeed, int ySpeed)
            : this(new Point(x, y), diameter, color, new Point(xSpeed, ySpeed))
        {
            //Pass-through ctor
        }

       
        public Ball(Point position, int diameter, Brush color, Point speed)
        {
            Position = position;
            this.color = color;
            Diameter = diameter;
            Speed = speed;
        }

        public virtual void Draw(Graphics gfx)
        {

        }

        //public void Draw(Graphics gfx)
        //{     
        //    gfx.FillEllipse(color, Position.X, Position.Y, Diameter, Diameter);
        //}

    }
}
