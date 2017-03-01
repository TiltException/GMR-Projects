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
            ball = new Ball();
            leftPaddle = new Paddle(null);
            rightPaddle = new Paddle(null, drawingBox.Right - 70, 10, 25, 125, 0, 2);
        }

        static bool mouseIsClicked()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                return true;
            }
            return false;
            
        }

        private void PongForm_Shown(object sender, EventArgs e)
        {

        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            ball.Draw(gfx);
            leftPaddle.Draw(gfx);
            rightPaddle.Draw(gfx);

            if (ball.Xpos < 0 || ball.Xpos + ball.Diameter >= drawingBox.Width)
            {
                ball.xSpeed *= -1;
            }

            if(ball.Ypos < 0 || ball.Ypos + ball.Diameter >= drawingBox.Height)
            {
                ball.ySpeed *= -1;
            }

            ball.Xpos += ball.xSpeed;
            ball.Ypos += ball.ySpeed;

            drawingBox.Image = bitmap;
        }

        private void PongForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                leftPaddle.Ypos -= leftPaddle.YSpeed;
            }
            if (e.KeyCode == Keys.Down)
            {
                leftPaddle.Ypos += leftPaddle.YSpeed;
            }
        }
    }
}
