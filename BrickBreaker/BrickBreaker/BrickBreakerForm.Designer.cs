namespace BrickBreaker
{
    partial class BrickBreakerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawingBox = new System.Windows.Forms.PictureBox();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.drawingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingBox
            // 
            this.drawingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingBox.Location = new System.Drawing.Point(0, 0);
            this.drawingBox.Name = "drawingBox";
            this.drawingBox.Size = new System.Drawing.Size(407, 291);
            this.drawingBox.TabIndex = 0;
            this.drawingBox.TabStop = false;
            // 
            // drawTimer
            // 
            this.drawTimer.Enabled = true;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // BrickBreakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 291);
            this.Controls.Add(this.drawingBox);
            this.Name = "BrickBreakerForm";
            this.Text = "Brick Breaker";
            this.Load += new System.EventHandler(this.BrickBreakerForm_Load);
            this.Resize += new System.EventHandler(this.BrickBreakerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.drawingBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingBox;
        private System.Windows.Forms.Timer drawTimer;
    }
}

