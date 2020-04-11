using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace TheTrailNorth
{
    [RegisterHandler("LaunchRequest")]
    public class LaunchRequest : RequestHandler
    {
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();
            response.Speech = "Welcome to The Trail North.";
            response.Reprompt = "Say something that you would like repeated.";
            
            return response;
        }
    }
    
    [RegisterHandler("RelayIntent",
        new[] {
            "Do something with the {test}",
            "Test the test with the {test}"
        })]
    public class RelayHandler : RequestHandler
    {
        [HandlerParam("AMAZON.SearchQuery", "speech")]
        public string Speech;

        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            response.Speech = Speech;
            response.Reprompt = "Say something that you would like repeated.";
            return response;
        }
    }
}
