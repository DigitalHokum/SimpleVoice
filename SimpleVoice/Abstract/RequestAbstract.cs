using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using SimpleVoice.Handlers;
using SimpleVoice.Handlers.Abstract;

namespace SimpleVoice.Abstract
{
    public abstract class RequestAbstract
    {
        public abstract ResponseAbstract BuildResponseObject();

        public abstract string GetIntentName();
        
        public abstract string GetClientId();

        public abstract RequestData GetData();

        public abstract string GetClientLocale();

        public abstract PurchaseRequest BuildPurchaseRequest();
    }
}
