using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace GameTime.Core.NHL
{
    /// <summary>
    /// Delegate used by NHLGameMonitor to relay any changes
    /// </summary>
    /// <param name="game"></param>
    public delegate void NHLGameHandler(Game game);

    /// <summary>
    /// NHLGameMonitor 
    /// </summary>
    public class NHLGameMonitor : IDisposable
    {
        /// <summary>
        /// Our default interval for how often we check for changes
        /// 10000 milliseconds = 10 seconds
        /// </summary>
        private const int DEFAULT_INTERVAL = 10000;

        private bool isRunning = false;
        private Timer monitorTimer;
        private NHLGameGrabber gameGrabber;
        private Dictionary<int, DateTime> gameUpdateTimes;
        
        /// <summary>
        /// Gets the GameGrabbrer used by the NHLGameMonitor class
        /// </summary>
        public NHLGameGrabber Grabber { get { return gameGrabber; } }
        /// <summary>
        /// Gets the latest update times of monitored games 
        /// </summary>
        public Dictionary<int, DateTime> UpdateTimes { get { return gameUpdateTimes; } }

        /// <summary>
        /// Gets if the monitor is running
        /// </summary>
        public bool IsRunning { get { return isRunning; } }

        /// <summary>
        /// An event that gets fired everytime a game that is being monitored is updated
        /// </summary>
        public event NHLGameHandler GameUpdated;

        /// <summary>
        /// Constructs a NHLGameMonitor object.
        /// Creates a new gamegrabber to work with
        /// </summary>
        public NHLGameMonitor()
            : this(new NHLGameGrabber())
        {
        }
        /// <summary>
        /// Constructs a NHLGameMonitor object
        /// </summary>
        /// <param name="nhlGrabber">The grabber to work with</param>
        public NHLGameMonitor(NHLGameGrabber nhlGrabber)
        {
            gameGrabber = nhlGrabber;

            gameUpdateTimes = new Dictionary<int, DateTime>();
            monitorTimer = new Timer(DEFAULT_INTERVAL);
            monitorTimer.Elapsed += Pulse;
            
        }
        /// <summary>
        /// Match ID to game
        /// </summary>
        /// <param name="id">the id of the game to match</param>
        /// <returns>matching game otherwise null</returns>
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
        /// <summary>
        /// Where the grabber updates every x seconds and data is parsed
        /// </summary>
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
                            if (game.LastUpdate != gameUpdateTimes[id] || game.LastUpdate > gameUpdateTimes[id] ||
                                game.BoxScore.LastUpdate > gameUpdateTimes[id])
                            {
                                updates.Add(game);
                            }
                        }
                    }
                }
            }
            foreach (Game game in updates)
            {
                gameUpdateTimes[game.Id] = game.BoxScore.LastUpdate;
                if (GameUpdated != null)
                    GameUpdated.Invoke(game);
            }
        }
        /// <summary>
        /// Tells the monitor to begin 
        /// </summary>
        public void Begin()
        {
            isRunning = true;
            gameGrabber.UpdateGames();
            monitorTimer.Start();
        }
        /// <summary>
        /// Tells the monitor to stop
        /// </summary>
        public void End()
        {
            monitorTimer.Stop();
            isRunning = false;
        }
        /// <summary>
        /// "Watch" a game based of id
        /// </summary>
        /// <param name="id">ID of the game to watch</param>
        public void Watch(int id)
        {
            if (!gameUpdateTimes.ContainsKey(id))
                gameUpdateTimes.Add(id, DateTime.MinValue);
        }
        /// <summary>
        /// "Watch" a game based off the name of the game
        /// </summary>
        /// <param name="gameName">name of the game to watch</param>
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
        /// <summary>
        /// Stop watching a certain game
        /// </summary>
        /// <param name="id">ID of a game to watch</param>
        public void Forget(int id)
        {
            if (gameUpdateTimes.ContainsKey(id))
                gameUpdateTimes.Remove(id);
        }
        /// <summary>
        /// Stop watching a certain game
        /// </summary>
        /// <param name="gameName">Name of the game to stop watching</param>
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
        /// <summary>
        /// Properly disposes of resources used by the object
        /// </summary>
        public void Dispose()
        {
            if (monitorTimer != null)
            {
                monitorTimer.Close();
                monitorTimer.Dispose();
            }
        }
    }
}