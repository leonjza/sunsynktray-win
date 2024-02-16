using System;
using System.Drawing;

namespace SunSynkTray
{
    internal static class Tools
    {
        public static Icon TextIcon(float num, Color color)
        {
            int iconSize = 16;

            using (Bitmap bitmap = new Bitmap(iconSize, iconSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Transparent);
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

                    using (Font font = new Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Pixel))
                    using (Brush brush = new SolidBrush(color))
                    {
                        StringFormat stringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center, // Center text horizontally
                            LineAlignment = StringAlignment.Center, // Center text vertically
                        };

                        // Draw the number in the center of the bitmap
                        Rectangle rectangle = new Rectangle(0, 0, iconSize, iconSize);

                        graphics.DrawString(num.ToString(), font, brush, rectangle, stringFormat);
                    }
                }

                using (Icon icon = Icon.FromHandle(bitmap.GetHicon()))
                {
                    return (Icon)icon.Clone();
                }
            }
        }

        public static Color PercentAsColor(float p)
        {
            if (p >= 80)
            {
                return Color.SpringGreen;
            }
            else if ((p < 80) && (p >= 60))
            {
                return Color.Yellow;
            }
            else if ((p < 60) && (p >= 40))
            {
                return Color.LightPink;
            }
            else 
            {
                return Color.OrangeRed; 
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
