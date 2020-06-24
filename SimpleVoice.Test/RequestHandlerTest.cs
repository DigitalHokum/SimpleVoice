using System.Threading.Tasks;
using SimpleVoice.Entry;
using Xunit;
using SimpleVoice.Platforms.Alexa;
using SimpleVoice.Platforms.Alexa.Data.Request;

namespace SimpleVoice.Test
{
    public class RequestHandlerTest
    {
        [Fact]
        public async Task VoiceHandlerSetupTest()
        {
            AlexaRequest request = MockData.AlexaRequest("SetupIntent");
            Lambda lambda = new Lambda();
            AlexaResponse response = (AlexaResponse) await lambda.HandleRequest(request);
            
            Assert.Equal("Setup Complete", response.Speech);
        }

        [Fact]
        public async Task VoiceHandlerRoutingAlexa()
        {
            AlexaRequest request = MockData.AlexaRequest("TestIntent");
            Lambda lambda = new Lambda();
            AlexaResponse response = (AlexaResponse) await lambda.HandleRequest(request);

            Assert.Equal("TestIntent Speech", response.Speech);
            Assert.Equal("TestIntent Reprompt", response.Reprompt);
        }
        
        [Fact]
        public async Task VoiceHandlerRelay()
        {
            string speechTextToRelay = "Relay this!";
            string repromptTextToRelay = "Also, Relay this!";
            AlexaRequest request = MockData.AlexaRequest("RelayIntent");
            request.Request.Intent.Slots.Add("speech", new Slot()
            {
                Name = "speech",
                Value = speechTextToRelay
            });
            request.Request.Intent.Slots.Add("reprompt", new Slot()
            {
                Name = "reprompt",
                Value = repromptTextToRelay
            });
            
            TestEntry lambda = new TestEntry();
            AlexaResponse response = (AlexaResponse) await lambda.HandleProxy(request);

            Assert.Equal(speechTextToRelay, response.Speech);
            Assert.Equal(repromptTextToRelay, response.Reprompt);
        }
    }
}
