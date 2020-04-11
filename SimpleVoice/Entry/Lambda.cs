using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Platforms.Alexa;
using SimpleVoice.Platforms.Alexa.Data.Request;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SimpleVoice.Entry
{
    public class Lambda : EntryAbstract
    {
        
        public ResponseAbstract Handle(JObject o, ILambdaContext context)
        {
            AlexaRequest request = o.ToObject<AlexaRequest>();
            ILambdaLogger logger = context.Logger;
            logger.Log($"Request Received by handler, Version: {o["version"]}");
            return HandleRequest(request);
        }
        
        public ResponseAbstract HandleRequest(RequestAbstract request)
        {
            string intentName = request?.GetIntentName();
            RegisterHandler handler = GetHandler(intentName);
            ResponseAbstract response = handler.Resolve(request);
            response.PrepareData();
            return response;
        }
    }
}
