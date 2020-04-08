using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SimpleVoice
{
    public class VoiceHandler
    {
        public SkillResponse AlexaHandler(SkillRequest input, ILambdaContext context)
        {
            SkillResponse response = new SkillResponse();
            ResponseBody responseBody = new ResponseBody();
            response.Response = responseBody;
            responseBody.ShouldEndSession = false;

            IOutputSpeech innerResponse = null;

            ILambdaLogger log = context.Logger;
            log.LogLine($"Skill Request Object: \n {JsonConvert.SerializeObject(input)}");
            
            
            return response;
        }
    }
}
