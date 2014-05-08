using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;

namespace GameTime.Core.NHL
{
    /// <summary>
    /// A implementation of GameGrabber targeted at the NHL catagory
    /// </summary>
    public class NHLGameGrabber : GameGrabber
    {
        private Game[] games;
        
        /// <summary>
        /// This event is called everytime the games are grabbed
        /// </summary>
        public event EventHandler Updated;
        
        /// <summary>
        /// Gets the array of games that has been grabbed 
        /// </summary>
        public Game[] Games
        {
            get { return games; }
        }
        /// <summary>
        /// Constructs the NHLGameGrabber object
        /// </summary>
        public NHLGameGrabber()
            : base("nhl")
        {
            games = null;
        }

        public override void UpdateGames()
        {
            games = null;
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(ScoreUrl);
                try
                {
                    games = JsonConvert.DeserializeObject<Game[]>(json);
                }
                catch (Newtonsoft.Json.JsonSerializationException ex)
                {
                    games = null;
                }
            }
            if (games != null && Updated != null)
                Updated.Invoke(this, null);
        }
    }
}
