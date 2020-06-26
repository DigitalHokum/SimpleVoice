using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Payload
    {
        [JsonProperty("InSkillProduct")] public InSkillProduct InSkillProduct;
        [JsonProperty("productId")] public string ProductId;
        [JsonProperty("purchaseResult")] public string PurchaseResult;
    }
}
