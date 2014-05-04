using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTime.Core.NHL;
namespace GameTime.Controls
{
    public partial class NHLGameView : UserControl
    {
        private Game game;

        public Game Game
        {
            get { return game; }
            set
            {
                game = value;
                if (game != null)
                {
                    gameNameLabel.Text = game.ToString();
                    gameTimeLabel.Text = Util.MilitaryToTwelve(game.Date.TimeOfDay);
                    homeTeamPictureBox.LoadAsync(game.HomeTeam.Logo.Small);
                    awayTeamPictureBox.LoadAsync(game.AwayTeam.Logo.Small);
                    if (game.BoxScore != null)
                    {
                        homeScore.Text = game.BoxScore.Score.Home.Score.ToString();
                        awayScore.Text = game.BoxScore.Score.Away.Score.ToString();
                    }
                    else
                    {
                        homeScore.Text = "0";
                        awayScore.Text = "0";
                    }
                }
            }
        }
        public NHLGameView()
            : this(null)
        {
        }
        public NHLGameView(Game nhlGame)
        {
            InitializeComponent();
            Game = nhlGame;
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
