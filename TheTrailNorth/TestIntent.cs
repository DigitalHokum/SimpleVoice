using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace TheTrailNorth
{
    [RegisterHandler("TestIntent")]
    public class TestIntent : RequestHandler
    {
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            return response;
        }
    }
}
