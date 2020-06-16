using System;
using System.Reflection;
using System.Threading.Tasks;
using SimpleVoice.Abstract;

namespace SimpleVoice.Handlers
{
    public abstract class RequestHandler
    {
        public abstract Task<ResponseAbstract> Handle(RequestAbstract request);
        
        public void SetParam(string key, string value)
        {
            Type t = GetType();
            FieldInfo f = t.GetField(key);
            f.SetValue(this, value);
        }
    }
}
