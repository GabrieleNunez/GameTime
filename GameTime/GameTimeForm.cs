using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTime.Core.NHL;
using GameTime.Controls;
using GameTime.GUI.NHL;
namespace GameTime
{
    public partial class GameTimeForm : Form
    {
        private NHLNotificationManager notifManager;

        public GameTimeForm()
        {
            InitializeComponent();
            notifManager = new NHLNotificationManager();
        }

        private void GameTimeForm_Load(object sender, EventArgs e)
        {
            notifManager.StartMonitor();
            notifManager.Monitor.Watch("Minnesota");
        }    
    }
}
