using Newtonsoft.Json;
using System;
using System.Net;

namespace GameTime.Core.NHL
{
    public class NHLGameGrabber : GameGrabber
    {
        private Game[] games;
        
        public Game[] Games
        {
            get { return games; }
        }

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
                games = JsonConvert.DeserializeObject<Game[]>(client.DownloadString(ScoreUrl));
            }
        }
    }
}
