using System.Collections.Generic;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

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
    }
}
