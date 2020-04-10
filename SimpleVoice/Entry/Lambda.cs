using Amazon.Lambda.Core;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace SimpleVoice.Entry
{
    public class Lambda : EntryAbstract
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public ResponseAbstract Handle(RequestAbstract request, ILambdaContext context)
        {
            string intentName = request.GetIntentName();
            RequestHandler handler = GetHandler(intentName);
            return handler.Resolve(request);
        }
    }
}
