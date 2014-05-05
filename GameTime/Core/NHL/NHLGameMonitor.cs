using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace GameTime.Core.NHL
{
    public delegate void NHLGameHandler(Game game);

    public class NHLGameMonitor : IDisposable
    {
        private const int DEFAULT_INTERVAL = 1000;

        private bool isRunning = false;
        private Timer monitorTimer;
        private NHLGameGrabber gameGrabber;
        private Dictionary<int, DateTime> gameUpdateTimes;
        
        public NHLGameGrabber Grabber { get { return gameGrabber; } }
        public Dictionary<int, DateTime> UpdateTimes { get { return gameUpdateTimes; } }

        public bool IsRunning { get { return isRunning; } }

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
                {
                    matchingGame = gameGrabber.Games[i];
                    break;
                }
            }
            return matchingGame;
        }
        private void Pulse(object sender, ElapsedEventArgs e)
        {
            gameGrabber.UpdateGames();
            List<Game> updates = new List<Game>();
            if (gameGrabber.Games.Length > 0)
            {
                if (gameUpdateTimes.Keys.Count > 0)
                {
                    foreach (int id in gameUpdateTimes.Keys)
                    {
                        Game game = IdMatch(id);
                        if (game != null)
                        {
                            if (game.LastUpdate != gameUpdateTimes[id] && game.LastUpdate > gameUpdateTimes[id])
                            {
                                updates.Add(game);
                            }
                        }
                    }
                }
            }
            foreach (Game game in updates)
            {
                gameUpdateTimes[game.Id] = game.LastUpdate;
                if (GameUpdated != null)
                    GameUpdated.Invoke(game);
            }
        }
        public void Begin()
        {
            isRunning = true;
            gameGrabber.UpdateGames();
            monitorTimer.Start();
        }
        public void End()
        {
            monitorTimer.Stop();
            isRunning = false;
        }
        public void Watch(int id)
        {
            if (!gameUpdateTimes.ContainsKey(id))
                gameUpdateTimes.Add(id, DateTime.MinValue);
        }
        public void Watch(string  gameName)
        {
            if (gameGrabber.Games != null)
            {
                foreach (Game game in gameGrabber.Games)
                {
                    if (game.ToString().ToLower() == gameName.ToLower())
                    {
                        Watch(game.Id);
                    }
                }
            }
        }
        public void Forget(int id)
        {
            if (gameUpdateTimes.ContainsKey(id))
                gameUpdateTimes.Remove(id);
        }
        public void Forget(string gameName)
        {
            if (gameGrabber.Games != null)
            {
                foreach (Game game in gameGrabber.Games)
                {
                    if (game.ToString().ToLower() == gameName.ToLower())
                    {
                        Forget(game.Id);
                    }
                }
            }
        }
        public void Dispose()
        {
            monitorTimer.Close();
            monitorTimer.Dispose();
        }
    }
}