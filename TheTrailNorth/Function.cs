using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace TheTrailNorth
{
    public class Function
    {
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apigProxyEvent, ILambdaContext context)
        {
            var body = new Dictionary<string, string>
            {
                { "message", "hello world" },
                { "location", "Unknown" }
            };

            return new APIGatewayProxyResponse
            {
                Body = JsonConvert.SerializeObject(body),
                StatusCode = 200,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
    }
}
