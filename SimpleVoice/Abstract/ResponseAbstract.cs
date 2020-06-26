using Newtonsoft.Json;

namespace SimpleVoice.Abstract
{
    public abstract class ResponseAbstract
    {
        [JsonIgnore] protected bool DataIsPrepared = false;
        
        [JsonIgnore] public string Reprompt;
        
        [JsonIgnore] public string Speech;
        
        [JsonIgnore] public bool EndSession = false;

        public abstract void PrepareData();
    }
}
