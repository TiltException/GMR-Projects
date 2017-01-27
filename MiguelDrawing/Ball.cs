using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiguelDrawing
{
    public class Ball
    {
        
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Radius { get; set; }
        public int xSpeed { get; set; }
        public int ySpeed { get; set; }
        private Brush color;
       
        public Ball()
        {
            Xpos = Ypos = 0;
            color = Brushes.Red;
            Radius = 50;
            xSpeed = 1;
            ySpeed = 1;
        }
        public void Draw(Graphics gfx)
        {     
            gfx.FillEllipse(color, Xpos, Ypos, Radius, Radius);
        }

    }
}
