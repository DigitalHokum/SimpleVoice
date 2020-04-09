using System;
using System.Collections.Generic;
using System.Reflection;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

namespace SimpleVoice
{
    public class VoiceHandler
    {

        private Dictionary<string, RequestHandler> _intents;
        
        public VoiceHandler()
        {
            Type t = GetType();
            var methods = t.GetMethods();
            _intents = new Dictionary<string, RequestHandler>();

            foreach (MethodInfo methodInfo in methods)
            {
                RequestHandler[] intents = (RequestHandler[]) methodInfo.GetCustomAttributes(typeof(RequestHandler));
                foreach (RequestHandler intent in intents)
                {
                    intent.RegisterMethod(methodInfo);
                    _intents.Add(intent.Name, intent);
                }
            }
        }

        private RequestHandler GetIntent(string name)
        {
            return _intents.ContainsKey(name) ? _intents[name] : null;
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public SkillResponse AlexaHandler(SkillRequest input, ILambdaContext context)
        {
            SkillResponse response = new SkillResponse();
            ResponseBody responseBody = new ResponseBody();
            response.Response = responseBody;
            responseBody.ShouldEndSession = false;

            IOutputSpeech innerResponse = null;

            Type requestType = input.GetRequestType();
            string intentName;
            RequestData data = new RequestData();
            
            if (requestType == typeof(LaunchRequest))
            {
                intentName = RequestHandler.LaunchRequest;
            }
            else if (requestType == typeof(IntentRequest))
            {
                IntentRequest request = (IntentRequest) input.Request;
                intentName = request.Intent.Name;
                // data["Test"] = request.Intent.Slots["Test"].Value;
            }
            else
            {
                intentName = RequestHandler.FallbackIntent;
            }

            RequestHandler requestHandler = GetIntent(intentName);

            if (requestHandler != null)
            {
                RequestHandlerResponse requestHandlerResponse = (RequestHandlerResponse) requestHandler.MethodInfo.Invoke(this, new object[] {data});
                responseBody.OutputSpeech = new SsmlOutputSpeech(requestHandlerResponse.Speech);
                responseBody.Reprompt = new Reprompt(requestHandlerResponse.Speech);
            }

            return response;
        }
    }
}
