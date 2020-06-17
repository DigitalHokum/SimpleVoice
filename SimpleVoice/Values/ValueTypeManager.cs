using System;
using System.Collections.Generic;
using System.Reflection;
using SimpleVoice.Helpers;

namespace SimpleVoice.Values
{
    public static class ValueTypeManager
    {
        public static readonly Dictionary<string, RegisterValueType> ValueTypes = new Dictionary<string, RegisterValueType>();

        public static void Discover()
        {
            ValueTypes.Clear();

            List<Assembly> assemblies = AssemblyHelper.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                foreach (KeyValuePair<string, RegisterValueType> pair in ScanAssembly(assembly))
                {
                    if (!ValueTypes.ContainsKey(pair.Key))
                        ValueTypes.Add(pair.Key, pair.Value);
                }
            }
        }
        
        public static Dictionary<string, RegisterValueType> ScanAssembly(Assembly assembly)
        {
            Dictionary<string, RegisterValueType> registerValueTypes = new Dictionary<string, RegisterValueType>();
            
            foreach (Type type in assembly.GetTypes())
            {
                RegisterValueType[] valueTypes = (RegisterValueType[]) type.GetCustomAttributes(typeof(RegisterValueType), false);
                if (valueTypes.Length > 0)
                {
                    foreach (RegisterValueType valueType in valueTypes)
                    {
                        valueType.Register(type);
                        registerValueTypes.Add(valueType.Name, valueType);
                    }
                }
            }

            return registerValueTypes;
        }
    }
}
