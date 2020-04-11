using Newtonsoft.Json;
using SimpleVoice.Handlers;

namespace SimpleVoice.Abstract
{
    public abstract class RequestAbstract
    {
        public abstract ResponseAbstract BuildResponseObject();

        public abstract string GetIntentName();

        public abstract RequestData GetData();
    }
}
