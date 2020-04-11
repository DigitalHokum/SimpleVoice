using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class OutputSpeech
    {
        [JsonProperty("type")]
        public string Type;
        
        [JsonProperty("ssml")]
        public string SSML;
    }
}