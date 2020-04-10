using Newtonsoft.Json;

namespace SimpleVoice.Abstract
{
    [JsonConverter(typeof(RequestConverter))]
    public abstract class RequestAbstract
    {
        public abstract ResponseAbstract BuildResponseObject();

        public abstract string GetIntentName();
    }
}
