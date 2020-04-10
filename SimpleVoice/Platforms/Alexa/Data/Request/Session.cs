using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Session
    {
        [JsonProperty("new")] public readonly bool New;

        [JsonProperty("sessionId")] public readonly string SessionId;

        [JsonProperty("attributes")] public readonly Dictionary<string, object> Attributes;

        [JsonProperty("application")] public readonly Application Application;

        [JsonProperty("user")] public readonly User User;
    }
}
