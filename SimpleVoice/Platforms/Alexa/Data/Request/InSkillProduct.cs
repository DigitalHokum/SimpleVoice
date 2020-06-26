using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class InSkillProduct
    {
        [JsonProperty("productId")] public string ProductId;
    }
}
