using System;
using System.Drawing;

namespace SunSynkTray
{
    internal static class Tools
    {
        public static Icon CreateIcon(float n1, int n2)
        {

            int iconSize = 32;

            using (Bitmap bitmap = new Bitmap(iconSize, iconSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Enable smoothing of the edge of the circle and the text
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    graphics.Clear(Color.Transparent);

                    // Set up the font and brush for drawing
                    // Adjust the font size as needed to make the number as large as possible while fitting in the icon
                    using (Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel))
                    using (Brush brush = new SolidBrush(Color.Yellow))
                    {
                        StringFormat stringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center, // Center text horizontally
                            LineAlignment = StringAlignment.Center, // Center text vertically
                        };

                        // Draw the number in the center of the bitmap
                        graphics.DrawString(n1.ToString(), font, brush, new RectangleF(0, 0, iconSize, iconSize), stringFormat);
                    }
                }

                // Convert the bitmap to an icon and return
                using (Icon icon = Icon.FromHandle(bitmap.GetHicon()))
                {
                    return (Icon)icon.Clone();
                }
            }

        }

        public static string TimeAgoFormat(DateTime time)
        {
            var timeSpan = DateTime.UtcNow - time.ToUniversalTime();

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                return $"{timeSpan.Seconds} seconds ago";
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1 ? $"{timeSpan.Minutes} minutes ago" : "a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1 ? $"{timeSpan.Hours} hours ago" : "an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                return timeSpan.Days > 1 ? $"{timeSpan.Days} days ago" : "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                int months = (int)(timeSpan.Days / 30);
                return months > 1 ? $"{months} months ago" : "a month ago";
            }
            else
            {
                int years = (int)(timeSpan.Days / 365);
                return years > 1 ? $"{years} years ago" : "a year ago";
            }
        }
    }
}
