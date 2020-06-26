using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Request
    {
        [JsonProperty("name")] public string Name;
        [JsonProperty("type")] public string Type;
        [JsonProperty("requestId")] public string RequestId;
        [JsonProperty("timestamp")] public string Timestamp;
        [JsonProperty("locale")] public string Locale;
        [JsonProperty("intent")] public Intent Intent;
        [JsonProperty("payload")] public Payload Payload;

        public bool HasIntent()
        {
            return Intent != null;
        }
    }
}
