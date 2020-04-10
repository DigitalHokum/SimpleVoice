using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace SimpleVoice.Test.Handlers
{
    [RequestHandler("TestIntent")]
    public class TestHandler : IRequestHandler
    {
        public ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();
            response.Speech = "TestIntent Speech";
            response.Reprompt = "TestIntent Reprompt";
            return response;
        }
    }
}
