using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GameTime
{
    public static class Util
    {
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
