using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameTime.Controls
{
    public partial class ControlBar : UserControl
    {
        public event EventHandler ControlBarClose;
        public ControlBar()
        {
            InitializeComponent();
            ControlBarClose += ControlBar_ControlBarClose;
        }

        void ControlBar_ControlBarClose(object sender, EventArgs e)
        {
            
        }

        private void closeLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.closeLabel.ForeColor = Color.Black;
        }

        private void closeLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.closeLabel.ForeColor = Color.WhiteSmoke;
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            ControlBarClose.Invoke(this, new EventArgs());
        }
    }
}
