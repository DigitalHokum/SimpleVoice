using System;
using System.Collections.Generic;

namespace SimpleVoice
{
    public interface IRequestHandler
    {
        RequestHandlerResponse Handle(RequestData data);
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RequestHandler : Attribute
    {
        // Built-in intents
        public static readonly string LaunchRequest = "LaunchRequest";
        public static readonly string FallbackIntent = "FallbackIntent";
        public static readonly string CancelIntent = "AMAZON.CancelIntent";
        public static readonly string StopIntent = "AMAZON.StopIntent";
        public static readonly string HelpIntent = "AMAZON.HelpIntent";

        public readonly string Name;
        private Type _type;
        public Type Type => _type;

        public RequestHandler(string name)
        {
            Name = name;
        }

        public void Register(Type type)
        {
            _type = type;
        }

        public RequestHandlerResponse Resolve(RequestData data)
        {
             IRequestHandler obj = (IRequestHandler) Activator.CreateInstance(_type);
             return obj.Handle(data);
        }
    }

    public class RequestData : Dictionary<string, string>
    {}

    public class RequestHandlerResponse
    {
        public readonly string Speech;
        public readonly string Reprompt;

        public RequestHandlerResponse(string speech, string reprompt)
        {
            Speech = speech;
            Reprompt = reprompt;
        }
    }
}
