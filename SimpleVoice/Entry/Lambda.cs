using System.Threading.Tasks;
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
        public async Task<ResponseAbstract> Handle(JObject o, ILambdaContext context)
        {
            AlexaRequest request = o.ToObject<AlexaRequest>();
            return await HandleRequest(request, context);
        }
        
        public async Task<ResponseAbstract> HandleRequest(AlexaRequest request, ILambdaContext context = null)
        {
            string intentName = request.GetIntentName();
            RegisterHandler handler = GetHandler(intentName);
            AlexaResponse response = (AlexaResponse) await handler.Resolve(request);
            response.PrepareData();
            return response;
        }
    }
}
