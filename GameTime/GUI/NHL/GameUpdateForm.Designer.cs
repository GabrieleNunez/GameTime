namespace GameTime.GUI.NHL
{
    partial class GameUpdateForm
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
            if (gradientBrush != null)
                gradientBrush.Dispose();
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
            this.controlBar1 = new GameTime.Controls.ControlBar();
            this.nhlGameView1 = new GameTime.Controls.NHLGameView();
            this.timeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // controlBar1
            // 
            this.controlBar1.BackColor = System.Drawing.Color.Transparent;
            this.controlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar1.Location = new System.Drawing.Point(0, 0);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.Size = new System.Drawing.Size(246, 18);
            this.controlBar1.TabIndex = 1;
            this.controlBar1.ControlBarClose += new System.EventHandler(this.controlBar1_ControlBarClose);
            // 
            // nhlGameView1
            // 
            this.nhlGameView1.BackColor = System.Drawing.Color.Transparent;
            this.nhlGameView1.Game = null;
            this.nhlGameView1.Location = new System.Drawing.Point(0, 0);
            this.nhlGameView1.Name = "nhlGameView1";
            this.nhlGameView1.Size = new System.Drawing.Size(228, 106);
            this.nhlGameView1.TabIndex = 0;
            // 
            // GameUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(246, 115);
            this.ControlBox = false;
            this.Controls.Add(this.nhlGameView1);
            this.Controls.Add(this.controlBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameUpdateForm";
            this.Text = "GameUpdateForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NHLGameView nhlGameView1;
        private Controls.ControlBar controlBar1;
        private System.Windows.Forms.Timer timeoutTimer;
    }
}