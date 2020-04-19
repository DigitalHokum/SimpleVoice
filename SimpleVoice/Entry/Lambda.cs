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
            logger.LogLine(o.ToString());
            return HandleRequest(request, context);
        }
        
        public ResponseAbstract HandleRequest(AlexaRequest request, ILambdaContext context = null)
        {
            ILambdaLogger logger = context.Logger;
            
            string intentName = request.GetIntentName();
            
            logger.LogLine($"Intent: {intentName}");
            
            RegisterHandler handler = GetHandler(intentName);
            AlexaResponse response = (AlexaResponse) handler.Resolve(request);
            response.PrepareData();
            logger.LogLine($"Response version {response.Version}");
            logger.LogLine($"Response speech {response.Response.OutputSpeech.SSML}");
            return response;
        }
    }
}
