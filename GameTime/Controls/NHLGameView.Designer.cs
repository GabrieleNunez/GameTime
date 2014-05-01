namespace GameTime.Controls
{
    partial class NHLGameView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.gameTimeLabel = new System.Windows.Forms.Label();
            this.homeTeamPictureBox = new System.Windows.Forms.PictureBox();
            this.awayTeamPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.homeScore = new System.Windows.Forms.Label();
            this.awayScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.homeTeamPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.awayTeamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.gameNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gameNameLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameLabel.Location = new System.Drawing.Point(0, 0);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(432, 29);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "Game Name Here";
            this.gameNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameTimeLabel
            // 
            this.gameTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameTimeLabel.AutoSize = true;
            this.gameTimeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.gameTimeLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.gameTimeLabel.Location = new System.Drawing.Point(347, 9);
            this.gameTimeLabel.Name = "gameTimeLabel";
            this.gameTimeLabel.Size = new System.Drawing.Size(73, 18);
            this.gameTimeLabel.TabIndex = 1;
            this.gameTimeLabel.Text = "x:xx pm";
            this.gameTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeTeamPictureBox
            // 
            this.homeTeamPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.homeTeamPictureBox.Location = new System.Drawing.Point(20, 46);
            this.homeTeamPictureBox.Name = "homeTeamPictureBox";
            this.homeTeamPictureBox.Size = new System.Drawing.Size(128, 128);
            this.homeTeamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.homeTeamPictureBox.TabIndex = 2;
            this.homeTeamPictureBox.TabStop = false;
            // 
            // awayTeamPictureBox
            // 
            this.awayTeamPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.awayTeamPictureBox.Location = new System.Drawing.Point(292, 46);
            this.awayTeamPictureBox.Name = "awayTeamPictureBox";
            this.awayTeamPictureBox.Size = new System.Drawing.Size(128, 128);
            this.awayTeamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.awayTeamPictureBox.TabIndex = 3;
            this.awayTeamPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "VS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeScore
            // 
            this.homeScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeScore.AutoSize = true;
            this.homeScore.BackColor = System.Drawing.SystemColors.Control;
            this.homeScore.Font = new System.Drawing.Font("Verdana", 10F);
            this.homeScore.Location = new System.Drawing.Point(74, 193);
            this.homeScore.Name = "homeScore";
            this.homeScore.Size = new System.Drawing.Size(17, 17);
            this.homeScore.TabIndex = 6;
            this.homeScore.Text = "0";
            this.homeScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // awayScore
            // 
            this.awayScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.awayScore.AutoSize = true;
            this.awayScore.BackColor = System.Drawing.SystemColors.Control;
            this.awayScore.Font = new System.Drawing.Font("Verdana", 10F);
            this.awayScore.Location = new System.Drawing.Point(347, 193);
            this.awayScore.Name = "awayScore";
            this.awayScore.Size = new System.Drawing.Size(17, 17);
            this.awayScore.TabIndex = 7;
            this.awayScore.Text = "0";
            this.awayScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NHLGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.awayScore);
            this.Controls.Add(this.homeScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.awayTeamPictureBox);
            this.Controls.Add(this.homeTeamPictureBox);
            this.Controls.Add(this.gameTimeLabel);
            this.Controls.Add(this.gameNameLabel);
            this.Name = "NHLGameView";
            this.Size = new System.Drawing.Size(432, 218);
            ((System.ComponentModel.ISupportInitialize)(this.homeTeamPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.awayTeamPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameNameLabel;
        private System.Windows.Forms.Label gameTimeLabel;
        private System.Windows.Forms.PictureBox homeTeamPictureBox;
        private System.Windows.Forms.PictureBox awayTeamPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label homeScore;
        private System.Windows.Forms.Label awayScore;
    }
}
