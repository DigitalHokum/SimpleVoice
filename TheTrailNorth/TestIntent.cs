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
            response.Speech = "<speak>Welcome to The Trail North.</speak>";
            response.Reprompt = "Say something that you would like repeated.";
            
            return response;
        }
    }
    
    [RegisterHandler("RelayIntent",
        new[] {
            "Do something with the {speech}",
            "Test the test with the {speech}"
        })]
    public class RelayHandler : RequestHandler
    {
        [HandlerParam("AMAZON.SearchQuery", "speech")]
        public string Speech;

        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            response.Speech = $"<speak>{Speech}</speak>";
            response.Reprompt = "Say something that you would like repeated.";
            return response;
        }
    }
    
    [RegisterHandler("AMAZON.FallbackIntent",
        new[] {
            "Do something with the {test}",
            "Test the test with the {test}"
        })]
    public class FallbackHandler : RequestHandler
    {
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            response.Speech = "<speak>This is the fallback handler</speak>";
            response.Reprompt = "Intent was not found, so this was invoked.";
            return response;
        }
    }
}
