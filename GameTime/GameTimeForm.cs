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
namespace GameTime
{
    public partial class GameTimeForm : Form
    {
        NHLGameGrabber nhlGrabber;
        public GameTimeForm()
        {
            InitializeComponent();
            nhlGrabber = new NHLGameGrabber();
        }

        private void GameTimeForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            nhlGrabber.UpdateGames();
            foreach (Game game in nhlGrabber.Games)
            {
                NHLGameView gameView = new NHLGameView(game);
                flowLayoutPanel1.Controls.Add(gameView);
            }
            this.Cursor = Cursors.Arrow;
        }
    }
}
