using System;
namespace GameTime.Core
{
    /// <summary>
    /// Abstract class that allows us to interact with the api of thescore
    /// Easily formats correct url to call and takes care of dates and times
    /// This is where and how we will grab all game data from
    /// </summary>
    public abstract class GameGrabber
    {
        /// <summary>
        /// thescore.com pulls all its game information through this json file that is requested
        /// it is properly formatted however it's works only on eastern time
        /// </summary>
        private const string BASE_SCORE_URL = "http://api.thescore.com/{0}/events?game_date.in={1}T04:00:00,{2}T04:00:00";
        /// <summary>
        /// Date format that specifies year-month-date and looks lik this 2014-05-01
        /// </summary>
        private const string DATE_FORMAT = "yyyy-MM-dd";
       
        private string scoreUrl;
        private string cat;

        /// <summary>
        /// Gets the url that points to the score api
        /// </summary>
        public string ScoreUrl { get { return scoreUrl; } }

        /// <summary>
        /// Constructs the object and correctly formats and sets a valid url
        /// </summary>
        /// <param name="catagory">What catagory do we ant to work with (nhl,basketball)</param>
        /// <remarks>Future reimplemntations may work through enum instead of string</remarks>
        public GameGrabber(string catagory)
        {
            cat = catagory;
            scoreUrl = string.Format(BASE_SCORE_URL,
                                    catagory, 
                                    DateTime.Today.ToString(DATE_FORMAT),
                                    DateTime.Today.AddDays(1.0d).ToString(DATE_FORMAT));
        }

        /// <summary>
        /// Where we connect and get the data from the source
        /// <remarks>Left abstract because how we want to process each catagory of games might be different</remarks>
        /// </summary>
        public abstract void UpdateGames();
    }
}
