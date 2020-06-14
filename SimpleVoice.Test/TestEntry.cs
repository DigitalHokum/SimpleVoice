using Amazon.Lambda.Core;
using SimpleVoice.Abstract;
using SimpleVoice.Entry;
using SimpleVoice.Platforms.Alexa;

namespace SimpleVoice.Test
{
    public class TestEntry : Lambda
    {
        public ResponseAbstract HandleProxy(AlexaRequest request, ILambdaContext context = null)
        {
            return HandleRequest(request, context);
        }
    }
}
