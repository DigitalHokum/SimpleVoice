using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleVoice.Handlers;
using SimpleVoice.ValueTypes;

namespace SimpleVoice.Platforms.Alexa.Data.InteractionModel
{
    public class InteractionModelBase
    {
        [JsonProperty("interactionModel")]
        public InteractionModel InteractionModel;

        public static InteractionModelBase Build(string invocationName, List<RegisterHandler> handlers, List<RegisterValueType> types)
        {
            InteractionModelBase model = new InteractionModelBase
            {
                InteractionModel = new InteractionModel
                {
                    LanguageModel = new LanguageModel
                    {
                        InvocationName = invocationName,
                        Intents = new List<Intent>(),
                        ValueTypes = new List<ValueType>()
                    }
                }
            };

            // Intents
            foreach (RegisterHandler handler in HandlerManager.Handlers.Values)
            {
                Intent intent = new Intent()
                {
                    Name = handler.Name,
                    Slots = new List<IntentSlot>(),
                    Samples = new List<string>()
                };
                model.InteractionModel.LanguageModel.Intents.Add(intent);

                // Slots
                if (handler.Params != null && handler.Params.Count > 0)
                {
                    foreach (HandlerParam param in handler.Params.Values)
                    {
                        IntentSlot slot = new IntentSlot
                        {
                            Name = param.Name,
                            Type = param.ValueType
                        };
                        intent.Slots.Add(slot);
                    }
                }
                
                // Samples
                if (handler.Utterances != null && handler.Utterances.Length > 0)
                {
                    foreach (string utterance in handler.Utterances)
                    {
                        intent.Samples.Add(utterance);
                    }
                }
            }

            // Value Types
            model.InteractionModel.LanguageModel.ValueTypes = new List<ValueType>();
            foreach (KeyValuePair<string, RegisterValueType> pair in ValueTypeManager.ValueTypes)
            {
                Type type = pair.Value.Type;
                SimpleVoice.ValueTypes.ValueType valueType = (SimpleVoice.ValueTypes.ValueType) Activator.CreateInstance(type);

                ValueType _valueType = new ValueType()
                {
                    Name = pair.Value.Name,
                    Values = new List<ValueTypeName>()
                };
                model.InteractionModel.LanguageModel.ValueTypes.Add(_valueType);
                
                foreach (string value in valueType.GetValues())
                {
                    _valueType.Values.Add(new ValueTypeName()
                    {
                        Name = new ValueTypeValue()
                        {
                            Value = value
                        }
                    });
                }
            }

            return model;
        }
    }
}
