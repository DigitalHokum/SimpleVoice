using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class ValueTypeName
    {
        [JsonProperty("name")] public ValueTypeValue Name;
    }
}
