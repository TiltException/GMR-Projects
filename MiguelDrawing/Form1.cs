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
    public partial class Form1 : Form
    {

        Bitmap bitmap;
        Graphics gfx;
        Ball ball;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(drawingBox.Width, drawingBox.Height);
            gfx = Graphics.FromImage(bitmap);
            ball = new Ball();
            while (true)
            {
                
                ball.Draw(gfx);
                drawingBox.Image = bitmap;
                drawingBox.Image = null;

                if (ball.Xpos <= 0 || ball.Xpos >= drawingBox.Width)
                {
                    ball.xSpeed *= -1;
                }

                ball.Xpos += ball.xSpeed;
                ball.Ypos += ball.ySpeed;
            }
            
        }

        static bool mouseIsClicked()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                return true;
            }
            return false;
            
        }
    }
}
