using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelSnakeGame
{
    public class Snake
    {
        private const int defaultLength = 10;
        private Point defaultPosition = new Point(30, 30);
        private List<SnakePiece> snake;

        public int Length => snake.Count;

        //Functionally equivalent to: public int Length => snake.Count;
        //public int Length2
        //{
        //    get
        //    {
        //        return snake.Count;
        //    }
        //}

        public SnakePiece Head => snake[0];

        //void stuff()
        //{
        //    var operations = new Dictionary<char, Func<int, int, int>>()
        //    {
        //        { '+', (a,b) => a + b },
        //        { '-', (a,b) => a - b },
        //        { '*', (a,b) => a * b },
        //        { '/', (a,b) => a / b }
        //    };

        //    int result = operations['+'](2, 3);
        //}        

        public Snake(Point point)
        {
            snake = new List<SnakePiece>(defaultLength)
            {
                new SnakePiece(point)
            };

            for(int i = 1; i < snake.Capacity; i++)
            {
                snake.Add(new SnakePiece(Head.Position.X - i, Head.Position.Y));
            }
        }
        public Snake(int x, int y) 
            : this(new Point(x,y))
        {
        }

        public void Grow()
        {
            //check the direction of the last piece on the snake
            //  switch(dirOfLastPiece)
            //      case Up: add below
            //      case Down: add above
            //      case Right: add to left
            //      case Left: add to right
            Point positionToAddAt;
            switch (snake[snake.Count - 1].direction)
            {
                case Direction.Up:
                    positionToAddAt = new Point(snake[snake.Count-1].Position.X, snake[snake.Count-1].Position.Y + MiguelSnakeGame.SnakePiece.defaultSize);
                    break;
                ca
            }
            snake.Add(new SnakePiece(snake[snake.Count].Position.X - SnakePiece.defaultSize, snake[snake.Count - 1].Position.Y, Brushes.Black));
        }

        public void Draw(Graphics gfx)
        {
            foreach (SnakePiece sp in snake)
            {
                sp.Draw(gfx);
            }
        }
    }
}
