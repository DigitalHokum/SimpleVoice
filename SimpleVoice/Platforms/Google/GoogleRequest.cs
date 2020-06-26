using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Handlers.Abstract;

namespace SimpleVoice.Platforms.Google
{
    public class GoogleRequest : RequestAbstract
    {
        public override ResponseAbstract BuildResponseObject()
        {
            return new GoogleResponse();
        }

        public override string GetIntentName()
        {
            throw new System.NotImplementedException();
        }

        public override string GetClientId()
        {
            throw new System.NotImplementedException();
        }

        public override RequestData GetData()
        {
            return new RequestData();
        }

        public override string GetClientLocale()
        {
            throw new System.NotImplementedException();
        }

        public override PurchaseRequest BuildPurchaseRequest()
        {
            throw new System.NotImplementedException();
        }

        public override ResponseAbstract BuildPurchaseResponseObject(string productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
