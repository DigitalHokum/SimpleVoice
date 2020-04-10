using Newtonsoft.Json;
using SimpleVoice.Abstract;

namespace SimpleVoice.Platforms.Alexa
{
    public class AlexaRequest : RequestAbstract
    {
        [JsonProperty("version")]
        public readonly string Version;
        
        [JsonProperty("session")]
        public readonly Data.Request.Session Session;
        
        [JsonProperty("context")]
        public readonly Data.Request.Context Context;
        
        [JsonProperty("request")]
        public readonly Data.Request.Request Request;
    }
}
