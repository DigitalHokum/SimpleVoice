using System.Threading.Tasks;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace SimpleVoice.Test.Handlers
{
    [RegisterHandler("SetupIntent")]
    public class SetupHandler : SimpleRequestHandler
    {
        public string Test;

        public override async Task Setup()
        {
            Test = "Setup Complete";
        }

        public override async Task<ResponseAbstract> Handle()
        {
            ResponseAbstract response = Request.BuildResponseObject();
            response.Speech = $"{Test}";
            response.Reprompt = "TestIntent Reprompt";
            return response;
        }
    }
}
