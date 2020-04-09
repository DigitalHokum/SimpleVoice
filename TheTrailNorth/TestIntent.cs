using SimpleVoice;

namespace TheTrailNorth
{
    [RequestHandler("TestIntent")]
    public class TestIntent : IRequestHandler
    {
        public RequestHandlerResponse Handle(RequestData data)
        {
            return new RequestHandlerResponse("Test Speech", "Test Reprompt");
        }
    }
}
