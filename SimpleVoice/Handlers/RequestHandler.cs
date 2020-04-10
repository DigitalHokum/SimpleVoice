using System;
using SimpleVoice.Abstract;

namespace SimpleVoice.Handlers
{
    public interface IRequestHandler
    {
        ResponseAbstract Handle(RequestAbstract request);
    }

    [AttributeUsage(AttributeTargets.Class)]
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

        public ResponseAbstract Resolve(RequestAbstract request)
        {
             IRequestHandler obj = (IRequestHandler) Activator.CreateInstance(_type);
             return obj.Handle(request);
        }
    }
}
