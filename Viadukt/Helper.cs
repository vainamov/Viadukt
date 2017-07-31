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
                return $"{bytes / 1024F, 0:N}KB";
            }
            if (bytes < Math.Pow(1024, 3)) {
                return $"{bytes / 1024F / 1024F, 0:N}MB";
            }
            if (bytes < Math.Pow(1024, 4)) {
                return $"{bytes / 1024F / 1024F / 1024F, 0:N}GB";
            }
            return $"{bytes / 1024F / 1024F / 1024F / 1024F, 0:N}TB";
        }
    }
}
