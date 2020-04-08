using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Xunit;
using Amazon.Lambda.TestUtilities;

namespace TheTrailNorth.Tests
{
  public class FunctionTest
  {
    private static readonly HttpClient client = new HttpClient();

    [Fact]
    public async Task TestHelloWorldFunctionHandler()
    {
            var request = new SkillRequest();
            var context = new TestLambdaContext();
            string location = "Unknown";
            
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "message", "hello world" },
                { "location", location },
            };

            var expectedResponse = new SkillResponse();

            var function = new Function();
            var response = function.AlexaHandler(request, context);

            /*
            Console.WriteLine("Lambda Response: \n" + response.Body);
            Console.WriteLine("Expected Response: \n" + expectedResponse.Body);

            Assert.Equal(expectedResponse.Body, response.Body);
            Assert.Equal(expectedResponse.Headers, response.Headers);
            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            */
    }
  }
}
