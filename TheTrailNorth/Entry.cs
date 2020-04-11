using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using SimpleVoice.Abstract;
using SimpleVoice.Entry;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace TheTrailNorth
{
    public class Entry : Lambda
    {
        public ResponseAbstract HandleProxy(JObject o, ILambdaContext context)
        {
            return Handle(o, context);
        }
    }
}
