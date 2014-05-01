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
        public ControlBar()
        {
            InitializeComponent();
        }

        private void closeLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            closeLabel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void closeLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            closeLabel.BorderStyle = BorderStyle.None;
        }
    }
}
