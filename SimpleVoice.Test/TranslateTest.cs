using System.Threading.Tasks;
using SimpleVoice.Internationalization;
using Xunit;

namespace SimpleVoice.Test
{
    public class TranslateTest
    {
        [Fact]
        public async Task SimpleTranslateStringTest()
        {
            Assert.Equal("This is a test.", Translate.String("This is a {0}.", "en-US", "test"));
        }
    }
}
