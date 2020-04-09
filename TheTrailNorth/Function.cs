using SimpleVoice;

namespace TheTrailNorth
{
    public class Function : VoiceHandler
    {
        [RequestHandler("TestIntent")]
        public RequestHandlerResponse TestIntent(RequestData data)
        {
            return new RequestHandlerResponse("Test Speech", "Test Reprompt");
        }
    }
}
