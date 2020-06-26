using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using SimpleVoice.Abstract;

namespace SimpleVoice.Handlers
{
    public abstract class RequestHandler
    {
        protected string Reprompt = "What would you like to do next?";
        protected List<string> Messages = new List<string>();
        protected RequestAbstract Request;
        public abstract Task<ResponseAbstract> Handle();

        public abstract Task Setup();

        public void SetParam(string key, string value)
        {
            Type t = GetType();
            FieldInfo f = t.GetField(key);
            f.SetValue(this, value);
        }

        protected string Translate(string toTranslate, params object[] args)
        {
            return Internationalization.Translate.String(toTranslate, Request.GetClientLocale(), args);
        }

        public void SetRequest(RequestAbstract request)
        {
            Request = request;
        }

        protected ResponseAbstract BuildResponse()
        {
            ResponseAbstract response = Request.BuildResponseObject();

            response.Speech = String.Join(" ", Messages);
            response.Reprompt = Reprompt;

            return response;	
        }
    }
}
