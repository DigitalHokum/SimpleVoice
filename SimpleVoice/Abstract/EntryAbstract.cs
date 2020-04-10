using System;
using System.Collections.Generic;
using System.Reflection;
using SimpleVoice.Handlers;

namespace SimpleVoice.Abstract
{
    public abstract class EntryAbstract
    {
        private Dictionary<string, RequestHandler> _handlers;
        
        public EntryAbstract()
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

        protected RequestHandler GetHandler(string name)
        {
            return _handlers.ContainsKey(name) ? _handlers[name] : null;
        }
    }
}
