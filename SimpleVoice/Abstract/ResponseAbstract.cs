using Newtonsoft.Json;

namespace SimpleVoice.Abstract
{
    public abstract class ResponseAbstract
    {
        [JsonIgnore]
        public string Reprompt;
        
        [JsonIgnore]
        public string Speech;

        public abstract void PrepareData();
    }
}
