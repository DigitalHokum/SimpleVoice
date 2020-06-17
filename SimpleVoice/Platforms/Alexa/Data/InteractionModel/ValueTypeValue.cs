using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class ValueTypeValue
    {
        [JsonProperty("value")]
        public string Value;
    }
}
