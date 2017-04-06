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
        private Random random;
        private bool GenerateNum;
        private int WinLoseNum;
        private bool UserWin;
        private static int defaultPaddleSpeed = 6;
        private static int defaultBallXSpeed = 4;
        private static int defaultBallYspeed = 4;
        private int PlayerScore;
        private int CpuScore;
        private Bitmap bitmap;
        private Graphics gfx;
        private Ball ball;
        private Paddle leftPaddle;
        private Paddle rightPaddle;
        private Point BallDestination;
        private Point PaddleDestination;

        public PongForm()
        {
            InitializeComponent();
        }
        private void PongForm_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(drawingBox.Width, drawingBox.Height);
            gfx = Graphics.FromImage(bitmap);
            GenerateNum = true;
            PlayerScore = 0;
            CpuScore = 0;
            random = new Random();
            UserWin = false;
            ball = new Ball(100, 50, 15, null, defaultBallXSpeed, defaultBallYspeed);
            BallDestination = new Point(0, 0);
            PaddleDestination = new Point(0, 0);
            leftPaddle = new Paddle(30, 20, 30, 150, 0, defaultPaddleSpeed, Brushes.Red);
            rightPaddle = new Paddle(drawingBox.Right - 70, 10, 25, 125, 0, defaultPaddleSpeed, Brushes.Blue);
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
           // gfx.DrawImage(MiguelDrawing.Properties.Resources.Wombat2, new Point(0, 0));
            ball.Draw(gfx);
            leftPaddle.Draw(gfx);
            rightPaddle.Draw(gfx);

            if (GenerateNum)
            {
                WinLoseNum = random.Next(1, 11);
            }

            if (WinLoseNum >= 1 && WinLoseNum <= 5)
            {
                UserWin = true;
                BallDestination = CalculateBallTrajectory();
                PaddleDestination = new Point(rightPaddle.Position.X, BallDestination.Y + 10);
            }

            else
            {
                UserWin = false;
            }

            #region ballLogic
            if (ball.Position.X < drawingBox.Left || ball.Position.X + ball.Size.Width > drawingBox.Right)
            {
                ResetBall();
                GenerateNum = true;
                if (ball.Position.X < drawingBox.Left)
                {
                    CpuScore++;
                }
                else
                {
                    PlayerScore++;
                }
                gfx.DrawString($"{PlayerScore} : {CpuScore}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold), Brushes.Black, new Point(drawingBox.Right / 2, drawingBox.Bottom / 5));
            }

            if (ball.isIntersectingLeftRight(leftPaddle) || ball.isIntersectingLeftRight(rightPaddle))
            {
                ball.Speed = new Point(ball.Speed.X * 2, ball.Speed.Y * 2);
                ball.Speed = new Point(ball.Speed.X * -1, ball.Speed.Y);
            }



            if (ball.Position.Y < 0 || ball.Position.Y + ball.Size.Width >= drawingBox.Height
                || ball.isIntersectingTopBot(leftPaddle)
                || ball.isIntersectingTopBot(rightPaddle))
            {
                ball.Speed = new Point(ball.Speed.X, ball.Speed.Y * -1);
            }
            #endregion ballLogic

            //if (UserWin && rightPaddle.Position.Y != BallDestination.Y + 10)
            //{
            //    rightPaddle.Update();
            //}
            //else
            //{
            //    rightPaddle.Position = new Point(rightPaddle.Position.X, ball.Position.Y - rightPaddle.Size.Height / 2);
            //}
            gfx.DrawString($"Destination:{BallDestination.X}, {BallDestination.Y}", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold), Brushes.Black, 20, 20);
            gfx.DrawString($"Current: {ball.Position.X}, {ball.Position.Y}", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold), Brushes.Black, 20, 50);
            ball.Update();
            gfx.DrawString(UpdatesUntilWin().ToString(), new Font(FontFamily.GenericSansSerif, 50, FontStyle.Bold), Brushes.Black, new Point(drawingBox.Right / 2, drawingBox.Top));
            drawingBox.Image = bitmap;
        }

        private void PongForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (leftPaddle.Position.Y > drawingBox.Top)
                {
                    leftPaddle.Speed = new Point(leftPaddle.Speed.X, Math.Abs(leftPaddle.Speed.Y) * -1);
                    leftPaddle.Update();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (leftPaddle.Position.Y + leftPaddle.Size.Height < drawingBox.Bottom)
                {
                    leftPaddle.Speed = new Point(leftPaddle.Speed.X, Math.Abs(leftPaddle.Speed.Y));
                    leftPaddle.Update();
                }
            }
        }

        private void ResetBall()
        {
            ball.Speed = new Point(defaultBallXSpeed, defaultBallYspeed);
            ball.Position = new Point((drawingBox.Right - drawingBox.Left) / 2, (drawingBox.Bottom - drawingBox.Top) / 2);
        }

        private int UpdatesUntilWin()
        {
            return (drawingBox.Right - ball.Position.X) / ball.Speed.X;
        }

        private int UpdatesUntilRefraction(Ball b)
        {
            if (b.Speed.Y < 0)
            {
                return (drawingBox.Bottom - b.Position.Y) / Math.Abs(b.Speed.X);
            }
            return Math.Abs(drawingBox.Top - b.Position.Y) / b.Speed.Y;
        }
        private Point CalculateBallTrajectory()
        {
            return nextCollision(ball);
        }

        private Point nextCollision(Ball b)
        {
            int newXpos;
            Ball ballAtNextCollisionPoint = b;
            for (;;)
            {
                //if ball collides with the right side, return the ball at this location
                if (ballAtNextCollisionPoint.Position.X >= drawingBox.Right)
                {
                    return b.Position;
                }
                //else return the ball at the next collision location with the Top/Bottom
                    //calculate next collision location at the top/bottom
                newXpos = ballAtNextCollisionPoint.Position.X + ballAtNextCollisionPoint.Speed.X * UpdatesUntilRefraction(b);

                if (b.Speed.Y < 0)
                {
                    ballAtNextCollisionPoint = new MiguelDrawing.Ball(new Point(newXpos, drawingBox.Bottom), b.Size, b.Color, new Point(b.Speed.X, b.Speed.Y * -1));
                }

                else
                {
                    ballAtNextCollisionPoint = new MiguelDrawing.Ball(new Point(newXpos, drawingBox.Top), b.Size, b.Color, new Point(b.Speed.X, b.Speed.Y * -1));
                }
            }
        }
    }
}
