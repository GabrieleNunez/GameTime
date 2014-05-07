using GameTime.Core.NHL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string currentWallpaper = DesktopWallpaper.GetCurrentWallpaper();
            using (NHLGameMonitor monitor = new NHLGameMonitor())
            {
                monitor.GameUpdated += monitor_GameUpdated;
                monitor.Begin();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (NHLSettingsForm form = new NHLSettingsForm(monitor))
                {
                    Application.Run(form);
                }
            }
            DesktopWallpaper.Change(currentWallpaper);
        }

       

        static void monitor_GameUpdated(Game game)
        {
            string path = Path.Combine(Application.StartupPath,string.Format("{0}.bmp", game.ToString()));
            Renderer.RenderGame(path,game);
            DesktopWallpaper.Change(path);
        }
    }
}
