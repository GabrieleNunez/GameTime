using GameTime.Core.NHL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GameTime
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NHLGameMonitor monitor = new NHLGameMonitor();
            monitor.GameUpdated += monitor_GameUpdated;
            monitor.Begin();
            monitor.Watch("Minnesota");
            Application.Run();
        }

        static void monitor_GameUpdated(Game game)
        {
            string path = Path.Combine(Application.StartupPath,string.Format("{0}.bmp", game.ToString()));
            Renderer.RenderScore(path,game);
            DesktopWallpaper.Change(path);
        }
    }
}
