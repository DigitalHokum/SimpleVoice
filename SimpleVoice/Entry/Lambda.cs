using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Platforms.Alexa;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SimpleVoice.Entry
{
    public class Lambda : EntryAbstract
    {
        
        public ResponseAbstract Handle(JObject o, ILambdaContext context)
        {
            AlexaRequest request = o.ToObject<AlexaRequest>();
            ILambdaLogger logger = context.Logger;
            logger.LogLine($"Request Received by handler, Version: {o["version"]}, IntentName: {request.GetIntentName()}");
            return HandleRequest(request, context);
        }
        
        public ResponseAbstract HandleRequest(AlexaRequest request, ILambdaContext context = null)
        {
            ILambdaLogger logger = context?.Logger;

            string intentName = request.GetIntentName();
            logger?.LogLine($"Found Intent: {intentName}");
            RegisterHandler handler = GetHandler(intentName);
            logger?.LogLine($"Handler: {handler.GetType()}");
            ResponseAbstract response = handler.Resolve(request);
            logger?.LogLine($"Response: {response.Speech}");
            response.PrepareData();
            return response;
        }
    }
}
