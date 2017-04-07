using System.Drawing;

namespace BrickBreaker
{
    public class MovingSprite : Sprite
    {
        public Point Speed { get; set; }

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