using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleVoice.Platforms.Alexa.Data.Response
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
    
    public class Body
    {
        [JsonProperty("version")]
        public string Version = "1.0";
        
        [JsonProperty("response")]
        public Response Response;
        
        [JsonProperty("sessionAttributes")]
        public Dictionary<string, object> SessionAttributes = new Dictionary<string, object>();
    }
}
