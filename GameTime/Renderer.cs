using GameTime.Core.NHL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameTime
{
    /// <summary>
    /// Renderer will take  any Game class and render it visually
    /// <remarks>
    /// Only supports NHL.Game at the moment
    /// </remarks>
    /// </summary>
    public static class Renderer
    {
        /// <summary>
        /// Default Width for our resolution
        /// </summary>
        private const int DEFAULT_WIDTH = 1920;
        /// <summary>
        /// Default Height for our resolution
        /// </summary>
        private const int DEFAULT_HEIGHT = 1080;

        /// <summary>
        /// Renders the data from the Game object visually into a Bitmap object and then saves it
        /// </summary>
        /// <param name="path">The path to save the bitmap</param>
        /// <param name="game">The Game object that has all the data we need to render</param>
        public static void RenderGame(string path,Game game)
        {
            using (Bitmap bitmap = new Bitmap(DEFAULT_WIDTH, DEFAULT_HEIGHT))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {

                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;

                    graphics.Clear(Color.Black);

                    using (Image homeLogo = Util.DownloadImage(game.HomeTeam.Logo.Large),
                                 awayLogo = Util.DownloadImage(game.AwayTeam.Logo.Large))
                    {
                        PointF imgPoint = new PointF();
                        int centerX = (DEFAULT_WIDTH / 2);
                        int centerY = (DEFAULT_HEIGHT / 2);
                        int homeLogoX = (centerX - (homeLogo.Width / 2)) + homeLogo.Width;
                        int homeLogoY = (centerY - (homeLogo.Height / 2));
                        imgPoint.X = homeLogoX;
                        imgPoint.Y = homeLogoY;
                        graphics.DrawImage(homeLogo, imgPoint);

                        int awayLogoX = (centerX - (awayLogo.Width / 2)) - awayLogo.Width;
                        int awayLogoY = (centerY - (awayLogo.Height / 2));
                        imgPoint.X = awayLogoX;
                        imgPoint.Y = awayLogoY;
                        graphics.DrawImage(awayLogo, imgPoint);
                        using (Font font = new Font("Impact", 50.0f, FontStyle.Regular))
                        {
                            using (SolidBrush brush = new SolidBrush(Color.White))
                            {
                                PointF point = new PointF();
                                SizeF size = graphics.MeasureString(game.ToString(), font);
                                point.X = centerX - (size.Width / 2);
                                point.Y = size.Height + 100;
                                graphics.DrawString(game.ToString(), font, brush, point);
                                
                                size =  graphics.MeasureString("vs", font);
                                point.Y = centerY + (size.Height / 2);
                                point.X = centerX;
                                graphics.DrawString("vs", font, brush, point);

                                string homeScore = string.Format("{0}",game.BoxScore != null ? game.BoxScore.Score.Home.Score : 0);
                                size = graphics.MeasureString(homeScore,font);
                                point.X = homeLogoX + (homeLogo.Width / 2);
                                point.Y = homeLogoY + (homeLogo.Height) + 100;
                                graphics.DrawString(homeScore, font, brush, point);

                                string awayScore = string.Format("{0}", game.BoxScore != null ? game.BoxScore.Score.Away.Score : 0);
                                size = graphics.MeasureString(awayScore, font);
                                point.X = awayLogoX + (awayLogo.Width / 2);
                                point.Y = awayLogoY + (awayLogo.Height) + 100;
                                graphics.DrawString(awayScore, font, brush, point);

                            }
                        }
                    }
                    bitmap.Save(path, ImageFormat.Bmp);
                }
            }
        }
    }
}