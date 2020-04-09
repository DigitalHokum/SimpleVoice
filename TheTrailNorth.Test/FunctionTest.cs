using System.Collections.Generic;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Xunit;
using Amazon.Lambda.TestUtilities;
using SimpleVoice;

namespace TheTrailNorth.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task TestIntent()
        {
            var request = new SkillRequest()
            {
            };
            var context = new TestLambdaContext();

            request.Request = new IntentRequest()
            {
                Intent = new Intent()
                {
                    Name = "TestIntent",
                    Slots = new Dictionary<string, Slot>()
                    {
                        {"Test", new Slot() {Value = "Test"}}
                    }
                }
            };

            var expectedResponse = new SkillResponse
            {
                Response = new ResponseBody()
                {
                    Reprompt = new Reprompt("Test Reprompt"),
                    OutputSpeech = new SsmlOutputSpeech("Test Speech")
                }
            };

            var function = new VoiceHandler();
            var response = function.LambdaHandler(request, context);
            Assert.Equal(((PlainTextOutputSpeech)(expectedResponse.Response.Reprompt.OutputSpeech)).Text, ((PlainTextOutputSpeech)(response.Response.Reprompt.OutputSpeech)).Text);
            Assert.Equal(((SsmlOutputSpeech)(expectedResponse.Response.OutputSpeech)).Ssml, ((SsmlOutputSpeech)(response.Response.OutputSpeech)).Ssml);
        }
    }
}
