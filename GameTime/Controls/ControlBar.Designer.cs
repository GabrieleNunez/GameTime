namespace GameTime.Controls
{
    partial class ControlBar
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
            this.closeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeLabel
            // 
            this.closeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeLabel.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closeLabel.Location = new System.Drawing.Point(59, 0);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(32, 26);
            this.closeLabel.TabIndex = 0;
            this.closeLabel.Text = "X";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeLabel.MouseEnter += new System.EventHandler(this.closeLabel_MouseEnter);
            this.closeLabel.MouseLeave += new System.EventHandler(this.closeLabel_MouseLeave);
            // 
            // ControlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.closeLabel);
            this.Name = "ControlBar";
            this.Size = new System.Drawing.Size(91, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label closeLabel;

    }
}
