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
                    gameTimeLabel.Text = ConvertMilitaryToTwelve(game.Date.TimeOfDay);
                    homeTeamPictureBox.LoadAsync(game.HomeTeam.Logo.Large);
                    awayTeamPictureBox.LoadAsync(game.AwayTeam.Logo.Large);
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
        private string ConvertMilitaryToTwelve(TimeSpan timeSpan)
        {
            int hour = 0;
            bool isPm = false;
            isPm = timeSpan.Hours >= 12 && timeSpan.Hours != 24;
            if (isPm && timeSpan.Hours != 12)
                hour = (timeSpan.Hours - 12);
            else if (timeSpan.Hours == 12 || timeSpan.Hours == 24)
                hour = 12;
            else
                hour = timeSpan.Hours;
            return string.Format("{0}:{1} {2}", hour, timeSpan.Minutes, isPm ? "pm" : "am");
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
