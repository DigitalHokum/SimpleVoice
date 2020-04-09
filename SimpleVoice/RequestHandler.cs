using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleVoice
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequestHandler : Attribute
    {
        // Built-in intents
        public static readonly string LaunchRequest = "LaunchRequest";
        public static readonly string FallbackIntent = "FallbackIntent";
        public static readonly string CancelIntent = "AMAZON.CancelIntent";
        public static readonly string StopIntent = "AMAZON.StopIntent";
        public static readonly string HelpIntent = "AMAZON.HelpIntent";

        public readonly string Name;
        private MethodInfo _methodInfo;
        public MethodInfo MethodInfo => _methodInfo;

        public RequestHandler(string name)
        {
            Name = name;
        }

        public void RegisterMethod(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
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
