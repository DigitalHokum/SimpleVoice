using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Request
    {
        [JsonProperty("type")] public string Type;
        [JsonProperty("requestId")] public string RequestId;
        [JsonProperty("timestamp")] public string Timestamp;
        [JsonProperty("locale")] public string Locale;
        [JsonProperty("intent")] public Intent Intent;

        public bool HasIntent()
        {
            return Intent != null;
        }
    }
}
