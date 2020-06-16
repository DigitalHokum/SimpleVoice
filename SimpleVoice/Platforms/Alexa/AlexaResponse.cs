using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleVoice.Abstract;
using SimpleVoice.Platforms.Alexa.Data.Response;

namespace SimpleVoice.Platforms.Alexa
{
    /*
    {
        "body": {
            "version": "1.0",
            "response": {
                "outputSpeech": {
                    "type": "SSML",
                    "ssml": "<speak>No Message</speak>"
                },
                "directives": [],
                "shouldEndSession": true,
                "type": "_DEFAULT_RESPONSE"
            },
            "sessionAttributes": {}
        }
    }
 */
    public class AlexaResponse : ResponseAbstract
    {
        [JsonProperty("version")]
        public string Version = "1.0";
        
        [JsonProperty("response")]
        public Response Response;
        
        [JsonProperty("sessionAttributes")]
        public Dictionary<string, object> SessionAttributes = new Dictionary<string, object>();

        public override void PrepareData()
        {
            Response = new Response()
            {
                OutputSpeech = new OutputSpeech()
                {
                    Type = "SSML",
                    SSML = $"<speak>{Speech} {Reprompt}</speak>"
                },
                Reprompt = new Reprompt()
                {
                    OutputSpeech = new OutputSpeech()
                    {
                        Type = "PlainText",
                        Text = Reprompt
                    }
                }
            };

            SessionAttributes = new Dictionary<string, object>()
            {
                {"launched", true}
            };
        }
    }
}
