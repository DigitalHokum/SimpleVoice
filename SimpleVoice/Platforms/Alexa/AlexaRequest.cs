using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Handlers.Abstract;
using SimpleVoice.Platforms.Alexa.Data.Response;

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

        protected ResponseAbstract BuildISPResponseObject(string productId, string speech, string action)
        {
            AlexaResponse response = (AlexaResponse) BuildResponseObject();
            response.Speech = speech;
            response.EndSession = true;
            response.PrepareData();
            
            response.Response.Directives = new List<Directive>
            {
                new Directive()
                {
                    Type = "Connections.SendRequest",
                    Name = action,
                    Token = Guid.NewGuid().ToString(),
                    Payload = new Dictionary<string, Dictionary<string, object>>()
                    {
                        {"InSkillProduct", new Dictionary<string, object>()
                            {
                                {"productId", productId}
                            }
                        }
                    }
                }
            };

            return response;
        }

        public override ResponseAbstract BuildPurchaseResponseObject(string productId, string speech)
        {
            return BuildISPResponseObject(productId, speech, "Buy");
        }

        public override ResponseAbstract BuildCancelResponseObject(string productId, string speech)
        {
            return BuildISPResponseObject(productId, speech, "Cancel");
        }

        public override string GetIntentName()
        {
            if (Request.Type == "IntentRequest")
                return Request.Intent.Name;
            
            if (Request.Type == "Connections.Response")
                return "ConnectionsResponse";

            if (Request.Type == "LaunchRequest")
                return "LaunchRequest";

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

            string productId = Request.Payload.InSkillProduct == null
                ? Request.Payload.ProductId
                : Request.Payload.InSkillProduct.ProductId;
            
            return new PurchaseRequest(result, action, productId);
        }
    }
}
