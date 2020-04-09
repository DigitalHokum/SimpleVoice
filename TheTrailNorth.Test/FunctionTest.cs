using System.Collections.Generic;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Xunit;
using Amazon.Lambda.TestUtilities;

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

            var function = new Function();
            var response = function.AlexaHandler(request, context);

            Assert.Equal(expectedResponse.Response.Reprompt.ToString(), response.Response.Reprompt.ToString());
            Assert.Equal(expectedResponse.Response.OutputSpeech.ToString(), response.Response.OutputSpeech.ToString());
        }
    }
}
