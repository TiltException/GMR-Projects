using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiguelDrawing
{
    public partial class PongForm : Form
    {

        private Bitmap bitmap;
        private Graphics gfx;
        private Ball ball;
        private Paddle leftPaddle;
        private Paddle rightPaddle;

        public PongForm()
        {
            InitializeComponent();
        }
        private void PongForm_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(drawingBox.Width, drawingBox.Height);
            gfx = Graphics.FromImage(bitmap);
            ball = new Ball(100, 50, 15, null, 2, 2);
            leftPaddle = new Paddle(30, 20, 30, 150, 0, 2, Brushes.Red);
            rightPaddle = new Paddle(drawingBox.Right - 70, 10, 25, 125, 0, 2, Brushes.Blue);
        }

        static bool mouseIsClicked()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                return true;
            }
            return false;
            
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            ball.Draw(gfx);
            leftPaddle.Draw(gfx);
            rightPaddle.Draw(gfx);

            if (ball.Position.X < 0 || ball.Position.X + ball.Size.Width >= drawingBox.Width
                || ball.isIntersectingLeftRight(leftPaddle)
                || ball.isIntersectingLeftRight(rightPaddle))
            {
                ball.Speed = new Point(ball.Speed.X * -1, ball.Speed.Y);
            }

            if(ball.Position.Y < 0 || ball.Position.Y + ball.Size.Width>= drawingBox.Height
                || ball.isIntersectingTopBot(leftPaddle)
                || ball.isIntersectingTopBot(rightPaddle))
            {
                ball.Speed = new Point(ball.Speed.X, ball.Speed.Y * -1);
            }

            if (rightPaddle.Position.Y > drawingBox.Top && rightPaddle.Position.Y + rightPaddle.Size.Height < drawingBox.Bottom)
            {
                rightPaddle.Speed = new Point(rightPaddle.Speed.X, Math.Abs(rightPaddle.Speed.Y));
            }

            else
            {
                rightPaddle.Speed = new Point(rightPaddle.Speed.X, Math.Abs(rightPaddle.Speed.Y) * -1);
            }

            rightPaddle.Update();

            //ball.Position.X += ball.xSpeed;
            //ball.Ypos += ball.ySpeed;
            //ball.Position = new Point(ball.Position.X + ball.Speed.X, ball.Position.Y + ball.Speed.Y);            
            ball.Update();

            drawingBox.Image = bitmap;
        }

        private void PongForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (leftPaddle.Position.Y > drawingBox.Top)
                {
                    //leftPaddle.Ypos -= leftPaddle.YSpeed;
                    leftPaddle.Speed = new Point(leftPaddle.Speed.X, Math.Abs(leftPaddle.Speed.Y)*-1);
                    leftPaddle.Update();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (leftPaddle.Position.Y + leftPaddle.Size.Height < drawingBox.Bottom)
                {
                    //leftPaddle.Ypos += leftPaddle.YSpeed;
                    leftPaddle.Speed = new Point(leftPaddle.Speed.X, Math.Abs(leftPaddle.Speed.Y));
                    leftPaddle.Update();
                }
            }
        }
    }
}
