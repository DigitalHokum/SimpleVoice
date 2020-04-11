using System;

namespace SimpleVoice.Handlers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequestHandlerSlot : Attribute
    {
        public readonly string Name;

        public RequestHandlerSlot(string name)
        {
            Name = name;
        }

    }
}
