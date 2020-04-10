using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Session
    {
        [JsonProperty("new")] public bool New;

        [JsonProperty("sessionId")] public string SessionId;

        [JsonProperty("attributes")] public Dictionary<string, object> Attributes;

        [JsonProperty("application")] public Application Application;

        [JsonProperty("user")] public User User;
    }
}
