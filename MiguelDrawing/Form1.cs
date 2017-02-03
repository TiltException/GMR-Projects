﻿using System;
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

        private Bitmap bitmap;
        private Graphics gfx;
        private Ball ball;
        private Paddle paddle1;
        private Paddle paddle2;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(drawingBox.Width, drawingBox.Height);
            gfx = Graphics.FromImage(bitmap);
            ball = new Ball();
            paddle1 = new Paddle(null);
            paddle2 = new Paddle(null);
        }

        static bool mouseIsClicked()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                return true;
            }
            return false;
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            ball.Draw(gfx);
            paddle1.Draw(gfx);
            paddle2.Draw(gfx);

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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                paddle1.Ypos -= paddle1.YSpeed;
            }
            if (e.KeyCode == Keys.Down)
            {
                paddle1.Ypos += paddle1.YSpeed;
            }
        }
    }
}
