using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleVoice.Platforms.Alexa;

namespace SimpleVoice.Abstract
{
    public class RequestConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            
            var target = new AlexaRequest();

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RequestAbstract);
        }
    }
}
