using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class LanguageModel
    {
        [JsonProperty("invocationName")]
        public string InvocationName;
        
        [JsonProperty("intents")]
        public List<Intent> Intents;
        
        [JsonProperty("types")]
        public List<ValueType> ValueTypes;
    }
}