using System.Threading.Tasks;

namespace SimpleVoice.Handlers
{
    public abstract class SimpleRequestHandler : RequestHandler
    {
        public override async Task Setup()
        {
            await Task.FromResult<string>(null);
        }
    }
}
