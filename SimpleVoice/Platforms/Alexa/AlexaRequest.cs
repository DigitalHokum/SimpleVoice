using Newtonsoft.Json;
using SimpleVoice.Abstract;

namespace SimpleVoice.Platforms.Alexa
{
    public class AlexaRequest : RequestAbstract
    {
        [JsonProperty("version")]
        public string Version;
        
        [JsonProperty("session")]
        public Data.Request.Session Session;
        
        [JsonProperty("context")]
        public Data.Request.Context Context;
        
        [JsonProperty("request")]
        public Data.Request.Request Request;

        public override ResponseAbstract BuildResponseObject()
        {
            return new AlexaResponse();
        }

        public override string GetIntentName()
        {
            return Request.Intent.Name;
        }
    }
}
