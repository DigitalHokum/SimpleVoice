using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class ValueType
    {
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("values")]
        public List<ValueTypeName> Values;
    }
}
