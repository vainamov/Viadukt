using System;

namespace Unfrosted
{
    public class Helper
    {
        public static string GetSizeString(long bytes) {
            if (bytes < 1024) {
                return $"{bytes}B";
            }
            if (bytes < Math.Pow(1024, 2)) {
                return $"{bytes / 1024}KB";
            }
            if (bytes < Math.Pow(1024, 3)) {
                return $"{bytes / 1024 / 1024}MB";
            }
            if (bytes < Math.Pow(1024, 4)) {
                return $"{bytes / 1024 / 1024 / 1024}GB";
            }
            return $"{bytes / 1024 / 1024 / 1024 / 1024}TB";
        }
    }
}
