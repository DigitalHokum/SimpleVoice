using Newtonsoft.Json;

namespace SimpleVoice.Abstract
{
    [JsonConverter(typeof(RequestConverter))]
    public abstract class RequestAbstract
    {
        
    }
}
