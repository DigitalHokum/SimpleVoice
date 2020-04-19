using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class OutputSpeech
    {
        [JsonProperty("type")]
        public string Type;
        
        [JsonProperty("ssml", NullValueHandling = NullValueHandling.Ignore)]
        public string SSML;

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text;
    }
}
