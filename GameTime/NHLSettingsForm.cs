using GameTime.Core.NHL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameTime
{

    public partial class NHLSettingsForm : Form
    {
        private delegate void AdjustmentMethod(Game[] games);
        private NHLGameMonitor gameMonitor;
        private AdjustmentMethod adjust;

        public NHLSettingsForm(NHLGameMonitor monitor)
        {
            InitializeComponent();
            gameMonitor = monitor;
            gameMonitor.Grabber.Updated += Grabber_Updated;
            adjust = AdjustGameList;
        }

        void Grabber_Updated(object sender, EventArgs e)
        {
            this.Invoke(adjust, new object[] { gameMonitor.Grabber.Games });
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Hide();
        }
        private void AdjustGameList(Game[] games)
        {
            for (int i = 0; i < gamesToolStripMenuItem.DropDownItems.Count; i++)
                gamesToolStripMenuItem.DropDownItems[i].Dispose();

            gamesToolStripMenuItem.DropDownItems.Clear();
            foreach (Game game in games)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = game.ToString();
                item.CheckOnClick = true;
                item.CheckedChanged += item_CheckedChanged;
                gamesToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void item_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked)
            {
                gameMonitor.Watch(item.Text);
            }
            else
                gameMonitor.Forget(item.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
