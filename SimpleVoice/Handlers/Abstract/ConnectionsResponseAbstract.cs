using System.Threading.Tasks;
using SimpleVoice.Abstract;

namespace SimpleVoice.Handlers.Abstract
{
    public enum EPurchaseAction
    {
        Buy,
        Cancel,
        Error
    }

    public enum EPurchaseResult
    {
        Accepted,
        Declined,
        AlreadyPurchased,
        Error
    }
    
    public readonly struct PurchaseRequest
    {
        public readonly EPurchaseResult Result;
        public readonly EPurchaseAction Action;
        public readonly string ProductId;

        public PurchaseRequest(EPurchaseResult result, EPurchaseAction action, string productId)
        {
            Result = result;
            Action = action;
            ProductId = productId;
        }
    }

    public abstract class ConnectionsResponseAbstract : RequestHandler
    {
        

        public abstract Task<ResponseAbstract> BuyAccepted(PurchaseRequest purchaseRequest);
        public abstract Task<ResponseAbstract> BuyAlreadyPurchased(PurchaseRequest purchaseRequest);
        public abstract Task<ResponseAbstract> BuyDeclined(PurchaseRequest purchaseRequest);
        public abstract Task<ResponseAbstract> CancelAccepted(PurchaseRequest purchaseRequest);
        public abstract Task<ResponseAbstract> CancelCancelled(PurchaseRequest purchaseRequest);
        public abstract Task<ResponseAbstract> Error(PurchaseRequest purchaseRequest);

        public override async Task<ResponseAbstract> Handle()
        {
            PurchaseRequest purchaseRequest = Request.BuildPurchaseRequest();

            if (purchaseRequest.Action == EPurchaseAction.Buy)
            {
                if (purchaseRequest.Result == EPurchaseResult.Accepted)
                    return await BuyAccepted(purchaseRequest);
                
                if (purchaseRequest.Result == EPurchaseResult.AlreadyPurchased)
                    return await BuyAlreadyPurchased(purchaseRequest);
                
                if (purchaseRequest.Result == EPurchaseResult.Declined)
                    return await BuyDeclined(purchaseRequest);
            }
            else if (purchaseRequest.Action == EPurchaseAction.Cancel)
            {
                if (purchaseRequest.Result == EPurchaseResult.Accepted)
                    return await CancelAccepted(purchaseRequest);
                
                if (purchaseRequest.Result == EPurchaseResult.Declined)
                    return await CancelCancelled(purchaseRequest);
            }

            return await Error(purchaseRequest);
        }
    }
}
