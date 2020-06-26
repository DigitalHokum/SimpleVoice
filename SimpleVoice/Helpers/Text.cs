using System;
using System.Collections.Generic;

namespace SimpleVoice.Helpers
{
    public class Text
    {
        public static string JoinListAnd(List<string> strings)
        {
            return String.Join(", ", strings);
        }
    }
}
