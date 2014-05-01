namespace GameTime.Forms.NHL
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nhlGameView1 = new GameTime.Controls.NHLGameView();
            this.controlBar1 = new GameTime.Controls.ControlBar();
            this.SuspendLayout();
            // 
            // nhlGameView1
            // 
            this.nhlGameView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nhlGameView1.Game = null;
            this.nhlGameView1.Location = new System.Drawing.Point(3, 29);
            this.nhlGameView1.Name = "nhlGameView1";
            this.nhlGameView1.Size = new System.Drawing.Size(432, 218);
            this.nhlGameView1.TabIndex = 0;
            // 
            // controlBar1
            // 
            this.controlBar1.BackColor = System.Drawing.Color.Transparent;
            this.controlBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar1.Location = new System.Drawing.Point(0, 0);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.Size = new System.Drawing.Size(447, 26);
            this.controlBar1.TabIndex = 1;
            // 
            // GameUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(447, 250);
            this.Controls.Add(this.controlBar1);
            this.Controls.Add(this.nhlGameView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameUpdateForm";
            this.Text = "GameUpdateForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NHLGameView nhlGameView1;
        private Controls.ControlBar controlBar1;
    }
}