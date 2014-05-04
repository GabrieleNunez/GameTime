using GameTime.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameTime.GUI.NHL
{
    public partial class GameUpdateForm : Form
    {
        public NHLGameView GameView { get { return nhlGameView1; } }

        private LinearGradientBrush gradientBrush;

        public GameUpdateForm()
        {
            InitializeComponent();
            gradientBrush = null;
        }

        private void CreateGradientBrush()
        {
            if(gradientBrush != null)
                gradientBrush.Dispose();
            gradientBrush = new LinearGradientBrush(this.ClientRectangle, 
                                                    Color.FromArgb(84, 84, 84), 
                                                    Color.FromArgb(51, 51, 51),
                                                    LinearGradientMode.Vertical);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            CreateGradientBrush();
            base.OnSizeChanged(e);
        }
        private void controlBar1_ControlBarClose(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            
        }
    }
}
