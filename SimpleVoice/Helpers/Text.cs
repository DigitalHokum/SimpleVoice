using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleVoice.Helpers
{
    public class Text
    {
        public static string JoinListAnd(List<string> strings)
        {
            return String.Join(", ", strings);
        }
        
        // Modified version of method found on https://stackoverflow.com/a/9472320/84498
        public static string Format(string format, Dictionary<string, string> data)
        {
            Regex r = new Regex(@"\{([A-Za-z0-9_]+)\}");

            MatchCollection m = r.Matches(format);

            foreach (Match item in m)
            {
                try
                {
                    string propertyName = item.Groups[1].Value;
                    format = format.Replace(item.Value, data[propertyName]);
                }
                catch
                {
                    throw new FormatException("The string format is not valid");
                }
            }

            return format;
        }
    }
}
