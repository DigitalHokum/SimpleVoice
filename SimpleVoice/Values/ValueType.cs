using System.Collections.Generic;

namespace SimpleVoice.Values
{
    public abstract class ValueType
    {
        public const string QUERY = "SimpleVoice.QUERY";

        public abstract List<string> GetValues();
    }
}
