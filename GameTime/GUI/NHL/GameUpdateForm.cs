using GameTime.Controls;
using GameTime.Core.NHL;
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

        public event EventHandler Timeout;
        private LinearGradientBrush gradientBrush;

        private const int DEFAULT_TIMEOUT = 10000;

        public Game Game
        {
            get { return nhlGameView1.Game; }
            set { nhlGameView1.Game = value; }
        }

        public GameUpdateForm()
        {
            InitializeComponent();
            gradientBrush = null;
            timeoutTimer.Interval = DEFAULT_TIMEOUT;
            timeoutTimer.Tick += timeoutTimer_Tick;
        }

        private void timeoutTimer_Tick(object sender, EventArgs e)
        {
            if (Timeout != null)
                Timeout.Invoke(this, null);
            this.Close();
            timeoutTimer.Stop();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timeoutTimer.Start();
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
    }
}
