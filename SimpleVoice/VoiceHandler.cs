using System;
using System.Collections.Generic;
using System.Reflection;
using Amazon.Lambda.Core;

namespace SimpleVoice
{
    public class VoiceHandler
    {
        private Dictionary<string, RequestHandler> _handlers;
        
        public VoiceHandler()
        {
            _handlers = new Dictionary<string, RequestHandler>();
            
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) 
            {
                foreach (Type type in assembly.GetTypes())
                {
                    RequestHandler[] handlers = (RequestHandler[]) type.GetCustomAttributes(typeof(RequestHandler), false);
                    if (handlers.Length > 0)
                    {
                        foreach (RequestHandler handler in handlers)
                        {
                            handler.Register(type);
                            _handlers.Add(handler.Name, handler);
                        }
                    }
                }
            }
        }

        private RequestHandler GetHandler(string name)
        {
            return _handlers.ContainsKey(name) ? _handlers[name] : null;
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public SkillResponse LambdaHandler(SkillRequest input, ILambdaContext context)
        {
            SkillResponse response = new SkillResponse();
            
            string intentName;
            RequestData data = new RequestData();
            
            IntentRequest request = (IntentRequest) input.Request;
            intentName = request.Intent.Name;
            // data["Test"] = request.Intent.Slots["Test"].Value;
            
            RequestHandler requestHandler = GetHandler(intentName);

            if (requestHandler != null)
            {
                RequestHandlerResponse requestHandlerResponse = requestHandler.Resolve(data);
                responseBody.OutputSpeech = new SsmlOutputSpeech(requestHandlerResponse.Speech);
                responseBody.Reprompt = new Reprompt(requestHandlerResponse.Reprompt);
            }

            return response;
        }
    }
}
