using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GameTime
{
    /// <summary>
    /// Static class that contains various Utility methods that can be used throughout the program
    /// <remarks>
    /// Anything inside the Util class are mostly helper methods that are isolated and don't require their own class to work
    /// </remarks>
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Downloads an image over the internet and returns an Image object
        /// </summary>
        /// <param name="url">The url pointing to the image</param>
        /// <returns>The image that has been downloaded</returns>
        public static Image DownloadImage(string url)
        {
            Image image = null;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream webStream = response.GetResponseStream())
                {
                    image = Image.FromStream(webStream);
                }
            }
            return image;
        }
        /// <summary>
        /// Converts military time to a standard twelve hour time and returns it as a string
        /// </summary>
        /// <param name="timeSpan">Timespan we are working with</param>
        /// <returns>Formatted string that represents the Timespan in a twelve hour format </returns>
        public static string MilitaryToTwelve(TimeSpan timeSpan)
        {
            int hour = 0;
            bool isPm = false;
            isPm = timeSpan.Hours >= 12 && timeSpan.Hours != 24;
            if (isPm && timeSpan.Hours != 12)
                hour = (timeSpan.Hours - 12);
            else if (timeSpan.Hours == 12 || timeSpan.Hours == 24)
                hour = 12;
            else
                hour = timeSpan.Hours;
            return string.Format("{0}:{1} {2}", hour, timeSpan.Minutes, isPm ? "pm" : "am");
        }
    }
}
