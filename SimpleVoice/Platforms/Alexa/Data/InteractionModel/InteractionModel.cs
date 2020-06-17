using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class InteractionModel
    {
        [JsonProperty("languageModel")]
        public LanguageModel LanguageModel;
    }
}