using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class Response
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeech OutputSpeech;
        
        [JsonProperty("reprompt")]
        public OutputSpeech Reprompt;
        
        [JsonProperty("shouldEndSession")]
        public bool ShouldEndSession = false;
        
        [JsonProperty("type")]
        public string Type = "_DEFAULT_RESPONSE";
        
        [JsonProperty("directives")]
        public List<string> Directives = new List<string>();
    }
}
