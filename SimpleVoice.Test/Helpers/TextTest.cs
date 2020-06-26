using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleVoice.Helpers;
using Xunit;

namespace SimpleVoice.Test.Helpers
{
    public class TextTest
    {
        [Fact]
        public async Task TextFormatAlexa()
        {
            string t = Text.Format("We are {FirstArg} to see if this {SecondArg}. Does it {SecondArg}?", new Dictionary<string, string>()
            {
                {"FirstArg", "testing"},
                {"SecondArg", "works"}
            });
            Assert.Equal("We are testing to see if this works. Does it works?", t);
        }
    }
}