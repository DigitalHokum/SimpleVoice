using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class IntentSlot
    {
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("type")]
        public string Type;
    }
}
