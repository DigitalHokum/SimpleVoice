using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class User
    {
        [JsonProperty("userId")] public string UserID;
    }
}
