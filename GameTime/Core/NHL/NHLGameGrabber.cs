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
                string json = client.DownloadString(ScoreUrl);
                try
                {
                    games = JsonConvert.DeserializeObject<Game[]>(json);
                }
                catch (Newtonsoft.Json.JsonSerializationException ex)
                {
                    throw new Exception("Failed to deserialize", ex);
                }
            }
        }
    }
}
