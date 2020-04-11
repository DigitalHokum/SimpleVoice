using Amazon.Lambda.Core;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;
using SimpleVoice.Platforms.Alexa;

namespace SimpleVoice.Entry
{
    public class Lambda : EntryAbstract
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public ResponseAbstract Handle(RequestAbstract request, ILambdaContext context)
        {
            string intentName = request.GetIntentName();
            RegisterHandler handler = GetHandler(intentName);
            ResponseAbstract response = handler.Resolve(request);
            response.PrepareData();
            return response;
        }
    }
}
