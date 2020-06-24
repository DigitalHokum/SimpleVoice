using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SimpleVoice.Abstract;

namespace SimpleVoice.Handlers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterHandler : Attribute
    {
        // Built-in intents
        public static readonly string LaunchRequest = "LaunchRequest";
        public static readonly string FallbackIntent = "FallbackIntent";
        public static readonly string CancelIntent = "AMAZON.CancelIntent";
        public static readonly string StopIntent = "AMAZON.StopIntent";
        public static readonly string HelpIntent = "AMAZON.HelpIntent";

        public readonly string Name;
        public readonly string[] Utterances;
        private Type _type;
        public Type Type => _type;
        public readonly Dictionary<FieldInfo, HandlerParam> Params = new Dictionary<FieldInfo, HandlerParam>();

        public RegisterHandler(string name)
        {
            Name = name;
        }
        
        public RegisterHandler(string name, string[] utterances)
        {
            Name = name;
            Utterances = utterances;
        }

        public void Register(Type type)
        {
            _type = type;
        }

        public void RegisterParam(FieldInfo field, HandlerParam handlerParam)
        {
            Params.Add(field, handlerParam);
        }

        public Task<ResponseAbstract> Resolve(RequestAbstract request)
        {
             RequestHandler obj = (RequestHandler) Activator.CreateInstance(_type);
             RequestData data = request.GetData();

             foreach (KeyValuePair<FieldInfo,HandlerParam> pair in Params)
             {
                 pair.Key.SetValue(obj, data.Get<string>(pair.Value.Name));
             }

             obj.SetRequest(request);
             obj.Setup();
             return obj.Handle();
        }
    }
}
