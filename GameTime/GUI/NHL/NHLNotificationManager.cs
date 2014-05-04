using GameTime.Core.NHL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameTime.GUI.NHL
{
    public class NHLNotificationManager : IDisposable
    {
        private Queue<GameUpdateForm> updateForms;
        private NHLGameMonitor nhlMonitor;

        public NHLNotificationManager()
        {
            updateForms = new Queue<GameUpdateForm>();
            nhlMonitor = new NHLGameMonitor();
            nhlMonitor.GameUpdated += nhlMonitor_GameUpdated;
        }

        private void nhlMonitor_GameUpdated(Game game)
        {
            GameUpdateForm form = new GameUpdateForm();
            form.GameView.Game = game;
        }

        public void Dispose()
        {
            if (nhlMonitor != null)
            {
                nhlMonitor.End();
                nhlMonitor.Dispose();
                nhlMonitor = null;
            }
            while (updateForms.Count > 0)
            {
                GameUpdateForm form = updateForms.Dequeue();
                form.Dispose();
            }
        }
    }
}
