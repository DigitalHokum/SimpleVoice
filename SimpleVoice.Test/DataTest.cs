using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleVoice.Platforms.Alexa;
using Xunit;

namespace SimpleVoice.Test
{
    public class DataTest
    {
        

        [Fact]
        public async Task VoiceHandlerRoutingAlexa()
        {
            AlexaRequest request = JsonConvert.DeserializeObject<AlexaRequest>(File.ReadAllText("/Users/mattroberts/Projects/Alexa/TheTrailNorth/SimpleVoice.Test/data/alexa/intent-request.json"));
            
            Assert.Equal("1.0", request.Version);
            Assert.Equal("TestIntent", request.GetIntentName());
        }
    }
}
