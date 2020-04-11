using System;
using System.Collections.Generic;
using System.Reflection;
using SimpleVoice.Handlers;

namespace SimpleVoice.Abstract
{
    public abstract class EntryAbstract
    {
        private Dictionary<string, RegisterHandler> _handlers;
        
        public EntryAbstract()
        {
            _handlers = new Dictionary<string, RegisterHandler>();
            
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) 
            {
                foreach (Type type in assembly.GetTypes())
                {
                    RegisterHandler[] handlers = (RegisterHandler[]) type.GetCustomAttributes(typeof(RegisterHandler), false);
                    if (handlers.Length > 0)
                    {
                        foreach (RegisterHandler handler in handlers)
                        {
                            handler.Register(type);
                            _handlers.Add(handler.Name, handler);
                            
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
        }

        protected RegisterHandler GetHandler(string name)
        {
            return _handlers.ContainsKey(name) ? _handlers[name] : null;
        }
    }
}
