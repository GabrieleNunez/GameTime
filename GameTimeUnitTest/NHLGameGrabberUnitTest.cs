using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameTime;
using GameTime.Core.NHL;
namespace GameTimeUnitTest
{
    [TestClass]
    public class NHLGameGrabberUnitTest
    {
        [TestMethod]
        public void Construct()
        {
            NHLGameGrabber grabber = new NHLGameGrabber();
            string actual = string.Format("http://api.thescore.com/{0}/events?game_date.in={1}T04:00:00,{2}T04:00:00",
                                    "nhl",
                                    DateTime.Today.ToString("yyyy-MM-dd"),
                                    DateTime.Today.AddDays(1.0d).ToString("yyyy-MM-dd"));
            Assert.AreEqual<string>(grabber.ScoreUrl,actual,"Malformed api url");
        }
    }
}
