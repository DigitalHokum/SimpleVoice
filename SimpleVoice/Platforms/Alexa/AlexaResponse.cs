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
        [JsonProperty("body")]
        public Body Body;

        public override void PrepareData()
        {
            Body = new Body()
            {
                Response = new Response()
                {
                    OutputSpeech = new OutputSpeech()
                    {
                        Type = "SSML",
                        SSML = Speech
                    },
                    Reprompt = new Reprompt()
                    {
                        OutputSpeech = new OutputSpeech()
                        {
                            Type = "SSML",
                            SSML = Reprompt
                        }
                    }
                },
                SessionAttributes = new Dictionary<string, object>()
                {
                    {"launched", true}
                }
            };
        }
    }
}
