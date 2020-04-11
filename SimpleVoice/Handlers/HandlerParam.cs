using System;

namespace SimpleVoice.Handlers
{
    [AttributeUsage(AttributeTargets.Field)]
    public class HandlerParam : Attribute
    {
        public readonly string ValueType;
        public readonly string Name;
        public HandlerParam(string valueType)
        {
            ValueType = valueType;
        }
        
        public HandlerParam(string valueType, string name)
        {
            ValueType = valueType;
            Name = name;
        }
    }
}
