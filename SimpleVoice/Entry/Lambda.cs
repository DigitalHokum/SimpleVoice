using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Helpers;
using SimpleVoice.Platforms.Alexa;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SimpleVoice.Entry
{
    public class Lambda : EntryAbstract
    {
        public ResponseAbstract Handle(JObject o, ILambdaContext context)
        {
            AlexaRequest request = o.ToObject<AlexaRequest>();
            return HandleRequest(request, context);
        }
        
        public ResponseAbstract HandleRequest(AlexaRequest request, ILambdaContext context = null)
        {
            string intentName = request.GetIntentName();
            RegisterHandler handler = GetHandler(intentName);
            AlexaResponse response = (AlexaResponse) handler.Resolve(request);
            response.PrepareData();
            return response;
        }
    }
}
