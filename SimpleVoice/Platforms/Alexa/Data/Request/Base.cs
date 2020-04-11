using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Base
    {
        [JsonProperty("version")]
        public string Version;
        
        [JsonProperty("session")]
        public Data.Request.Session Session;
        
        [JsonProperty("context")]
        public Data.Request.Context Context;
        
        [JsonProperty("request")]
        public Data.Request.Request Request;
    }
}
