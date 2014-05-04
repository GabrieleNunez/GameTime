using GameTime.Core.NHL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public NHLGameMonitor Monitor { get { return nhlMonitor; } }
        public NHLNotificationManager()
        {
            
            updateForms = new Queue<GameUpdateForm>();
            nhlMonitor = new NHLGameMonitor();
            nhlMonitor.GameUpdated += nhlMonitor_GameUpdated;
        }
        public void StartMonitor()
        {
            nhlMonitor.Begin();
        }
        public void StopMonitor()
        {
            nhlMonitor.End();
        }
        private void nhlMonitor_GameUpdated(Game game)
        {
            Debug.WriteLine("Game updated: " + game.ToString());
            GameUpdateForm form = new GameUpdateForm();
            lock (game)
            {
                form.GameView.Game = game;

                int desktopWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int desktopHeight = Screen.PrimaryScreen.WorkingArea.Height;

                int x = desktopWidth - form.Size.Width;
                int y = (100 * updateForms.Count) + 25;
                form.Location = new Point(x, y);
                form.Timeout += form_Timeout;
                updateForms.Enqueue(form);
                form.Show();
            }
        }

        private void form_Timeout(object sender, EventArgs e)
        {
            updateForms.Dequeue();
        }
        public void Update()
        {
            // not implemented
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
