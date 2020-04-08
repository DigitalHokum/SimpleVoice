using Amazon.Lambda.Core;
using SimpleVoice;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace TheTrailNorth
{
    public class Function : VoiceHandler
    {
        
    }
}
