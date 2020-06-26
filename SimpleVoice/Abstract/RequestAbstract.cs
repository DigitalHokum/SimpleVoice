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
        public abstract ResponseAbstract BuildPurchaseResponseObject(string productId, string speech);
    }
}
