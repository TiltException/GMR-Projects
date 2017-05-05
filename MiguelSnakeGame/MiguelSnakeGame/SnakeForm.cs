using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiguelSnakeGame
{
    public partial class SnakeForm : Form
    {
        private Graphics gfx;
        private Bitmap bitmap;
        

        public SnakeForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(drawingBox.Width, drawingBox.Height);
            gfx = Graphics.FromImage(bitmap);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
