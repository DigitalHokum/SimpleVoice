using SimpleVoice.Abstract;

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
    }
}
