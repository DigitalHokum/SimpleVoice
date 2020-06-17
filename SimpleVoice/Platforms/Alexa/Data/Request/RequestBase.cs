using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class RequestBase
    {
        [JsonProperty("version")]
        public string Version;
        
        [JsonProperty("session")]
        public Session Session;
        
        [JsonProperty("context")]
        public Context Context;
        
        [JsonProperty("request")]
        public Request Request;
    }
}
