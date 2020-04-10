using System.Threading.Tasks;
using Amazon.Lambda.TestUtilities;
using SimpleVoice.Entry;
using Xunit;
using SimpleVoice.Platforms.Alexa;

namespace SimpleVoice.Test
{
    public class RequestHandlerTest
    {
        [Fact]
        public async Task VoiceHandlerRoutingAlexa()
        {
            AlexaRequest request = MockData.AlexaRequest("TestIntent");
            Lambda lambda = new Lambda();
            AlexaResponse response = (AlexaResponse) lambda.Handle(request, new TestLambdaContext());
            
            
            Assert.Equal("TestIntent Speech", response.Speech);
            Assert.Equal("TestIntent Reprompt", response.Reprompt);
        }
    }
}
