using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class Intent
    {
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("slots")]
        public List<IntentSlot> Slots;
        
        [JsonProperty("samples")]
        public List<string> Samples;
    }
}
