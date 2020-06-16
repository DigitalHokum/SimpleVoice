using System;
using System.Collections.Generic;
using System.Reflection;
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

        public ResponseAbstract Resolve(RequestAbstract request)
        {
             RequestHandler obj = (RequestHandler) Activator.CreateInstance(_type);
             RequestData data = request.GetData();

             foreach (KeyValuePair<FieldInfo,HandlerParam> pair in Params)
             {
                 pair.Key.SetValue(obj, data.Get<string>(pair.Value.Name));
             }
             
             return obj.Handle(request);
        }

        public static Dictionary<string, RegisterHandler> Discover()
        {
            Dictionary<string, RegisterHandler> handlers = new Dictionary<string, RegisterHandler>();
            
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) 
            {
                foreach (Type type in assembly.GetTypes())
                {
                    RegisterHandler[] _handlers = (RegisterHandler[]) type.GetCustomAttributes(typeof(RegisterHandler), false);
                    if (_handlers.Length > 0)
                    {
                        foreach (RegisterHandler handler in _handlers)
                        {
                            handler.Register(type);
                            handlers.Add(handler.Name, handler);
                            
                            foreach (FieldInfo field in type.GetFields())
                            {
                                HandlerParam[] handlerParams = (HandlerParam[]) field.GetCustomAttributes(typeof(HandlerParam));
                                if (handlerParams.Length > 0)
                                {
                                    foreach (HandlerParam param in handlerParams)
                                    {
                                        handler.RegisterParam(field, param);   
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return handlers;
        }
    }
}
