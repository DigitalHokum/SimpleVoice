using System.Collections.Generic;

namespace SimpleVoice.Handlers
{
    public class RequestData : Dictionary<string, object>
    {
        public T Get<T>(string key)
        {
            return ContainsKey(key) ? (T) this[key] : default(T);
        }
    }
}
