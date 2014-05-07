using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GameTime
{
    /// <summary>
    /// Represents the current wallpaper that is set on the deskop
    /// </summary>
    public static class DesktopWallpaper
    {
        //Actions to pass to our imported SystemParametersInfo() 
        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPI_GETDESKWALLPAPER = 0x73;
        
        //specific update commands
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;

        /// <summary>
        /// Imported function call from user32.dll allows us to retrieve system wide parameters.
        /// </summary>
        /// <param name="uiAction">Action to perform</param>
        /// <param name="uiParam">Additional parameter supplied.</param>
        /// <param name="pvParam">Typically the buffer of data to write to</param>
        /// <param name="fWinIni"></param>
        /// <remarks>pvParam  in this case is fielded as a string object</remarks>
        /// <returns>Value that marks success or failure</returns>
        [DllImport("user32.dll",CharSet=CharSet.Auto)]
        private static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        /// <summary>
        /// Retrieves the CURRENT wallpaper that is set and active
        /// </summary>
        /// <returns>Path that points to the file</returns>
        public static string GetCurrentWallpaper()
        {
            string data = new string('\0',500);
            SystemParametersInfo(SPI_GETDESKWALLPAPER,500, data, 0);
            return data;
        }
        /// <summary>
        /// Gets the current wallpaper and saves it to the specified path
        /// </summary>
        /// <param name="path">Where to copy the wallpaper</param>
        public static void BackupCurrentWallpaper(string path)
        {
            string originalWallpaper = GetCurrentWallpaper();
            File.Copy(originalWallpaper, path, true);

        }
        /// <summary>
        /// Change the wallpaper to point to the specified path
        /// </summary>
        /// <param name="path">Where the new wallpaper is stored</param>
        public static void Change(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
        
    }
}
