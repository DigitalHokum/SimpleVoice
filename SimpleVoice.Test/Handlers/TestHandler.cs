using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace SimpleVoice.Test.Handlers
{
    [RegisterHandler("TestIntent")]
    public class TestHandler : RequestHandler
    {
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();
            response.Speech = "TestIntent Speech";
            response.Reprompt = "TestIntent Reprompt";
            return response;
        }
    }
}
