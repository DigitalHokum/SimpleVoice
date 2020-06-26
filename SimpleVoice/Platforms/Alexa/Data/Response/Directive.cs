using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class Directive
    {
        [JsonProperty("type")] public string Type;
        [JsonProperty("name")] public string Name;
        [JsonProperty("payload")] public DirectivePayload Payload;
        [JsonProperty("token")] public string Token;
    }
}