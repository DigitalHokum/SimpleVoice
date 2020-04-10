using Amazon.Lambda.Core;
using SimpleVoice.Abstract;

namespace SimpleVoice.Entry
{
    public class Lambda : EntryAbstract
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public ResponseAbstract LambdaHandler(RequestAbstract requestAbstract, ILambdaContext context)
        {
            return null;
        }
    }
}
