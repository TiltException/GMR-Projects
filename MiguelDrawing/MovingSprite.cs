using System.Drawing;

namespace MiguelDrawing
{
    public class MovingSprite : Sprite
    {
        public Point Speed { get; private set; }

        public MovingSprite(Point position, Size size, Brush color, Point speed)
            : base(position, size, color)
        {
            Speed = speed;
        }

        public virtual void Update()
        {
            Position = new Point(Position.X + Speed.X, Position.Y + Speed.Y);
        }
    }
}