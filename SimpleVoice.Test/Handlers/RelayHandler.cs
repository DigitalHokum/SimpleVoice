using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace SimpleVoice.Test.Handlers
{
    [RegisterHandler("RelayIntent",
        new[] {
            "Do something with the {test}",
            "Test the test with the {test}"
        })]
    public class RelayHandler : RequestHandler
    {
        [HandlerParam(Slots.TestSlot, "speech")]
        public string Speech;
        
        [HandlerParam(Slots.TestSlot, "reprompt")]
        public string Reprompt;
        
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            response.Speech = Speech;
            response.Reprompt = Reprompt;
            return response;
        }
    }
}
