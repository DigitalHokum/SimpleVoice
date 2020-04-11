using System;
using System.Reflection;
using SimpleVoice.Abstract;

namespace SimpleVoice.Handlers
{
    public abstract class RequestHandler
    {
        public abstract ResponseAbstract Handle(RequestAbstract request);
        
        public void SetParam(string key, string value)
        {
            Type t = GetType();
            FieldInfo f = t.GetField(key);
            f.SetValue(this, value);
        }
    }
}
