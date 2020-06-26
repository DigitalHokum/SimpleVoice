using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class Response
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeech OutputSpeech;
        
        [JsonProperty("reprompt", NullValueHandling = NullValueHandling.Ignore)]
        public Reprompt Reprompt;
        
        [JsonProperty("shouldEndSession")]
        public bool ShouldEndSession = false;
        
        [JsonProperty("type")]
        public string Type = "_DEFAULT_RESPONSE";
        
        [JsonProperty("directives", NullValueHandling = NullValueHandling.Ignore)]
        public List<Directive> Directives;
    }
}
