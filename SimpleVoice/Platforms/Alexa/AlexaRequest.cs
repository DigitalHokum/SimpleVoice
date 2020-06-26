using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Handlers.Abstract;

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

            return "AMAZON.FallbackIntent";
        }

        public override string GetClientId()
        {
            return Session.User.UserID;
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

        public override string GetClientLocale()
        {
            return Request.Locale;
        }

        public override PurchaseRequest BuildPurchaseRequest()
        {
            EPurchaseResult result = EPurchaseResult.Error;
            
            switch (Request.Payload.PurchaseResult)
            {
                case "ACCEPTED":
                    result = EPurchaseResult.Accepted;
                    break;
                case "DECLINED":
                    result = EPurchaseResult.Declined;
                    break;
                case "ALREADY_PURCHASED":
                    result = EPurchaseResult.AlreadyPurchased;
                    break;
            }
            
            EPurchaseAction action = EPurchaseAction.Error;
            switch (Request.Name)
            {
                case "Buy":
                    action = EPurchaseAction.Buy;
                    break;
                case "Cancel":
                    action = EPurchaseAction.Cancel;
                    break;
            }
            
            string productId = Request.Payload.InSkillProduct.ProductId;
            
            return new PurchaseRequest(result, action, productId);
        }
    }
}
