using Newtonsoft.Json;
using SimpleVoice.Abstract;

namespace SimpleVoice.Platforms.Alexa
{
    public class AlexaResponse : ResponseAbstract
    {
        [JsonProperty("version")]
        public string Version;
    }
}
