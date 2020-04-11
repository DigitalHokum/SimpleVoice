using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace SimpleVoice.Platforms.Alexa
{
    public class AlexaRequest : RequestAbstract
    {
        [JsonProperty("version")]
        public string Version;
        
        [JsonProperty("session")]
        public Data.Request.Session Session;
        
        [JsonProperty("context")]
        public Data.Request.Context Context;
        
        [JsonProperty("request")]
        public Data.Request.Request Request;

        public override ResponseAbstract BuildResponseObject()
        {
            return new AlexaResponse();
        }

        public override string GetIntentName()
        {
            if (Request.Type == "IntentRequest")
            {
                return Request.Intent.Name;    
            }
            else if (Request.Type == "LaunchRequest")
            {
                return "LaunchRequest";
            }

            return "FallbackIntent";
        }

        public override RequestData GetData()
        {
            RequestData data = new RequestData();

            if (!Request.HasIntent() || !Request.Intent.HasSlotData())
                return data;
            
            foreach (KeyValuePair<string, Data.Request.Slot> pair in Request.Intent.Slots)
            {
                data[pair.Value.Name] = pair.Value.Value;
            }
            
            return data;
        }
    }
}