using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Slot
    {
        [JsonProperty("name")] public string Name;
        [JsonProperty("value")] public string Value;
    }
}
