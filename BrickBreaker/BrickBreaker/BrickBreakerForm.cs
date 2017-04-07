using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BrickBreaker
{
    public partial class BrickBreakerForm : Form
    { 
               
        private Bitmap bitmap;
        private Graphics gfx;

        private const int defaultBallRadius = 10;
        private Point defaultBallPosition = new Point(50,50);
        private Brush defaultColor = Brushes.Black;
        private Point defaultBallSpeed = new Point(2,2);
        private Ball ball;

        private int defaultBrickWidth = 35;
        private int defaultBrickHeight = 10;
        private int defaultBrickSpacing = 2;
        private List<Brick> bricks;

        public BrickBreakerForm()
        {
            InitializeComponent();
        }
        private void BrickBreakerForm_Load(object sender, EventArgs e)
        {
            
            bitmap = new Bitmap(drawingBox.Width, drawingBox.Height);
            gfx = Graphics.FromImage(bitmap);
            ball = new BrickBreaker.Ball(defaultBallPosition,new Size(defaultBallRadius, defaultBallRadius),defaultColor,defaultBallSpeed);
            //figure out how many bricks to generate and initialize
            int numBricks = drawingBox.Width / (defaultBrickWidth + defaultBrickSpacing);
            bricks = new List<Brick>(numBricks);
            for (int i = 0, curPos = 0; i < numBricks; i++, curPos += (defaultBrickWidth+ defaultBrickSpacing))
            {
                bricks.Add(new Brick(curPos, 0, defaultBrickWidth, defaultBrickHeight, Brushes.Black));
            }
        }
        private void BrickBreakerForm_Resize(object sender, EventArgs e)
        {
            //set to original size
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            foreach (Brick brick in bricks)
            {
                brick.Draw(gfx);
            }
            drawingBox.Image = bitmap;
        }

       
    }
}
