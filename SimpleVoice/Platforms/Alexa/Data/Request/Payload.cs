using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Payload
    {
        [JsonProperty("InSkillProduct")] public InSkillProduct InSkillProduct;
        [JsonProperty("purchaseResult")] public string PurchaseResult;
    }
}