using System;

namespace SimpleVoice.ValueTypes
{
    public class RegisterValueType : Attribute
    {
        public readonly string Name;
        private Type _type;
        public Type Type => _type;
        
        
        public RegisterValueType(string name)
        {
            Name = name;
        }

        public void Register(Type type)
        {
            _type = type;
        }
    }
}
