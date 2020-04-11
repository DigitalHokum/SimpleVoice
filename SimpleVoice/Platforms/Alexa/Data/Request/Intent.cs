using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Request
{
    public class Intent
    {
        [JsonProperty("name")] public string Name;
        [JsonProperty("confirmationStatus")] public string ConfirmationStatus;
        [JsonProperty("slots")] public Dictionary<string, Slot> Slots;

        public bool HasSlotData()
        {
            return Slots != null && Slots.Count > 0;
        }
    }
}
