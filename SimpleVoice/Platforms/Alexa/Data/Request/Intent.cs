using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Intent
    {
        [JsonProperty("name")] public string Name;
        [JsonProperty("confirmationStatus")] public string ConfirmationStatus;
    }
}
