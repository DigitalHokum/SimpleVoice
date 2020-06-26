using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class InSkillProductDirective
    {
        [JsonProperty("productId")] public string ProductId;
    }
}