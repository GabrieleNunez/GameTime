using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GameTime
{
    public static class DesktopWallpaper
    {
        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPI_GETDESKWALLPAPER = 0x73;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;

        
        [DllImport("user32.dll",CharSet=CharSet.Auto)]
        private static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        public static string GetCurrentWallpaper()
        {
            string data = new string('\0',500);
            SystemParametersInfo(SPI_GETDESKWALLPAPER,500, data, 0);
            Debug.WriteLine(data);
            return data;
        }
        public static void Change(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
        
    }
}
