using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class Directive
    {
        [JsonProperty("type")] public string Type;
        [JsonProperty("name")] public string Name;
        [JsonProperty("token")] public string Token;
        [JsonProperty("payload")] public Dictionary<string, Dictionary<string, object>> Payload;
    }
}