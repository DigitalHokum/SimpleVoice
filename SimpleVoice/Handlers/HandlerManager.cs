using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SimpleVoice.Helpers;

namespace SimpleVoice.Handlers
{
    public static class HandlerManager
    {
        public static readonly Dictionary<string, RegisterHandler> Handlers = new Dictionary<string, RegisterHandler>();

        public static void Discover()
        {
            Handlers.Clear();
            List<Assembly> assemblies = AssemblyHelper.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                foreach (KeyValuePair<string,RegisterHandler> pair in ScanAssembly(assembly))
                {
                    if (!Handlers.ContainsKey(pair.Key))
                        Handlers.Add(pair.Key, pair.Value);
                }
            }
        }
        
        public static Dictionary<string, RegisterHandler> ScanAssembly(Assembly assembly)
        {
            Dictionary<string, RegisterHandler> handlers = new Dictionary<string, RegisterHandler>();
            
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

            return handlers;
        }
    }
}
