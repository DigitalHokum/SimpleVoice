using Newtonsoft.Json;
using SimpleVoice.Handlers;

namespace SimpleVoice.Abstract
{
    [JsonConverter(typeof(RequestConverter))]
    public abstract class RequestAbstract
    {
        public abstract ResponseAbstract BuildResponseObject();

        public abstract string GetIntentName();

        public abstract RequestData GetData();
    }
}
