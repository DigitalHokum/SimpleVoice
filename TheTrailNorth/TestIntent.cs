using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace TheTrailNorth
{
    [RequestHandler("TestIntent")]
    public class TestIntent : IRequestHandler
    {
        public ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            return response;
        }
    }
}
