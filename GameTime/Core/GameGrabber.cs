using System;
namespace GameTime.Core
{
    public abstract class GameGrabber
    {
        private const string BASE_SCORE_URL = "http://api.thescore.com/{0}/events?game_date.in={1}T04:00:00,{2}T04:00:00";
        private const string DATE_FORMAT = "yyyy-MM-dd";
       
        private string scoreUrl;
        private string cat;

        public string ScoreUrl { get { return scoreUrl; } }

        public GameGrabber(string catagory)
        {
            cat = catagory;
            scoreUrl = string.Format(BASE_SCORE_URL,
                                    catagory, 
                                    DateTime.Today.ToString(DATE_FORMAT),
                                    DateTime.Today.AddDays(1.0d).ToString(DATE_FORMAT));
        }

        public abstract void UpdateGames();
    }
}
