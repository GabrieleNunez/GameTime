using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GameTime.Core.NHL
{
    public delegate void NHLGameHandler(Game game);

    public class NHLGameMonitor : IDisposable
    {
        private const int DEFAULT_INTERVAL = 5000;

        private Timer monitorTimer;
        private NHLGameGrabber gameGrabber;
        private Dictionary<int, DateTime> gameUpdateTimes;

        public NHLGameGrabber Grabber { get { return gameGrabber; } }
        public Dictionary<int, DateTime> UpdateTimes { get { return gameUpdateTimes; } }

        public int WatchingCount { get { return gameUpdateTimes.Values.Count; } }

        public event NHLGameHandler GameUpdated;

        public NHLGameMonitor()
            : this(new NHLGameGrabber())
        {
        }
        public NHLGameMonitor(NHLGameGrabber nhlGrabber)
        {
            gameGrabber = nhlGrabber;

            gameUpdateTimes = new Dictionary<int, DateTime>();
            monitorTimer = new Timer(DEFAULT_INTERVAL);
            monitorTimer.Elapsed += Pulse;
            
        }

        private Game IdMatch(int id)
        {
            Game matchingGame = null;
            for (int i = 0; i < gameGrabber.Games.Length; i++)
            {
                if (gameGrabber.Games[i].Id == id)
                    matchingGame = gameGrabber.Games[i];
            }
            return matchingGame;
        }
        private void Pulse(object sender, ElapsedEventArgs e)
        {
            gameGrabber.UpdateGames();
            if (gameGrabber.Games.Length > 0)
            {
                foreach (int id in gameUpdateTimes.Keys)
                {
                    Game game = IdMatch(id);
                    if (game != null)
                    {
                        if (game.LastUpdate != gameUpdateTimes[id] && game.LastUpdate > gameUpdateTimes[id])
                        {
                            gameUpdateTimes[id] = game.LastUpdate;
                            if (GameUpdated != null)
                                GameUpdated.Invoke(game);
                        }
                    }
                }
            }
        }
        public void Begin()
        {
            monitorTimer.Start();
        }
        public void End()
        {
            monitorTimer.Stop();
        }
        public void Watch(int id)
        {
            if (gameUpdateTimes.ContainsKey(id))
                gameUpdateTimes.Add(id, DateTime.MinValue);
        }
        public void Forget(int id)
        {
            if (gameUpdateTimes.ContainsKey(id))
                gameUpdateTimes.Remove(id);
        }
        public void Dispose()
        {
            monitorTimer.Close();
            monitorTimer.Dispose();
        }
    }
}