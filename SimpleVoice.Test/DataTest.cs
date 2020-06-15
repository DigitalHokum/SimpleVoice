using System;
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
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            AlexaRequest request = JsonConvert.DeserializeObject<AlexaRequest>(File.ReadAllText(Path.Combine(projectDirectory, "data/alexa/intent-request.json")));
            
            Assert.Equal("1.0", request.Version);
            Assert.Equal("TestIntent", request.GetIntentName());
        }
    }
}
