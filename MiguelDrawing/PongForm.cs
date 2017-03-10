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
        private static int defaultPaddleSpeed = 6;
        private static int defaultBallXSpeed = 2;
        private static int defaultBallYspeed = 2;
        private int PlayerScore;
        private int CpuScore;
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
            GenerateNum = true;
            PlayerScore = 0;
            CpuScore = 0;
            random = new Random();
            ball = new Ball(100, 50, 15, null, defaultBallXSpeed, defaultBallYspeed);
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
            gfx.DrawImage(MiguelDrawing.Properties.Resources.Wombat2, new Point(0,0));
            ball.Draw(gfx);
            leftPaddle.Draw(gfx);
            rightPaddle.Draw(gfx);

            if (GenerateNum)
            {
                WinLoseNum = random.Next(1, 11);
            }

            #region ballLogic
            if (ball.Position.X < drawingBox.Left || ball.Position.X + ball.Size.Width> drawingBox.Right)
            {
                ResetBall();
                if (ball.Position.X < drawingBox.Left)
                {
                    CpuScore++;
                }
                else
                {
                    PlayerScore++;
                }
                gfx.DrawString($"{PlayerScore} : {CpuScore}",new Font(FontFamily.GenericSansSerif,3, FontStyle.Bold), Brushes.Black, new Point(drawingBox.Right / 2, drawingBox.Bottom / 5));         
            }
            if (ball.isIntersectingLeftRight(leftPaddle) || ball.isIntersectingLeftRight(rightPaddle))
            {
                ball.Speed = new Point(ball.Speed.X * 2, ball.Speed.Y * 2);
                ball.Speed = new Point(ball.Speed.X * -1, ball.Speed.Y);
            }

            

            if(ball.Position.Y < 0 || ball.Position.Y + ball.Size.Width>= drawingBox.Height
                || ball.isIntersectingTopBot(leftPaddle)
                || ball.isIntersectingTopBot(rightPaddle))
            {
                ball.Speed = new Point(ball.Speed.X, ball.Speed.Y * -1);
            }
            #endregion ballLogic

            if (rightPaddle.Position.Y < 0 || rightPaddle.Position.Y + rightPaddle.Size.Height > drawingBox.Bottom)
            {
                rightPaddle.Speed = new Point(rightPaddle.Speed.X, rightPaddle.Speed.Y * -1);
            }
            

            rightPaddle.Update();

            //ball.Position.X += ball.xSpeed;
            //ball.Ypos += ball.ySpeed;
            //ball.Position = new Point(ball.Position.X + ball.Speed.X, ball.Position.Y + ball.Speed.Y);            
            ball.Update();

            drawingBox.Image = bitmap;
        }

        private void hello()
        {

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

        private void ResetBall()
        {
            ball.Speed = new Point(defaultBallXSpeed, defaultBallYspeed);
            ball.Position = new Point((drawingBox.Right - drawingBox.Left) / 2, (drawingBox.Bottom - drawingBox.Top) / 2);
        }

        private int updatesUntilCollision()
        {
            return (drawingBox.Right - ball.Position.X) / ball.Speed.X;
        }
        private Point calculateBallTrajectory()
        { 
            
        }
    }
}
