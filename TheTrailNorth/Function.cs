using Amazon.Lambda.Core;
using SimpleVoice;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
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
