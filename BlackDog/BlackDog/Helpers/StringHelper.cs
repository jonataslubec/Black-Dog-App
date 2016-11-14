using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlackDog.Helpers
{
    public static class StringHelper
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string HttpUrlFix(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (value.Contains("http"))
            {
                return value;
            }
            else
            {
                return string.Format("http:{0}", value);
            }
        }

        public static string RemoveTags(string HTML)
        {
            return Regex.Replace(HTML, "<[^>]*>", "");
        }

        public static string FixPathImage(string path)
        {
            if (App.IsWindows10)
            {
                return string.Format("Resources/{0}", path);
            }
            else
            {
                return path;
            }
        }

        public static string HttpUrlFixAuth(string http, string u, string s)
        {
            return string.Format("http://{0}:{1}@{2}", u, s, http.Replace("http://", "").Replace("https://", ""));
        }

        public static string TruncateCharAtIndex(this string value, string characterToTruncate, int characterAtIndex)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var index = IndexOfNth(value, characterToTruncate, characterAtIndex);
            return value.Substring(0, index + 1);
        }

        public static int IndexOfNth(string str, string value, int nth = 1)
        {
            if (nth <= 0)
                throw new ArgumentException("Não pode encontrar index 0");
            int offset = str.IndexOf(value);
            for (int i = 1; i < nth; i++)
            {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }
            return offset;
        }

        public static string TwitterUrl(this string value)
        {
            return string.Format(@"http:\\twitter.com\{0}", value);

        }
    }
}
