using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
{
    public class DirectivePayload
    {
        [JsonProperty("InSkillProduct", NullValueHandling = NullValueHandling.Ignore)]
        public InSkillProductDirective InSkillProduct;
    }
}
