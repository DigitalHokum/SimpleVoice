using SimpleVoice.Platforms.Alexa;
using SimpleVoice.Platforms.Alexa.Data.Request;

namespace SimpleVoice.Test
{
    public class MockData
    {
        public static AlexaRequest AlexaRequest(string intent)
        {
            return new AlexaRequest()
            {
                Version = "1.0",
                Session = new Session()
                {
                    New = true,
                    SessionId = "amz1.session.test"
                },
                Context = new Context()
                {

                },
                Request = new Request()
                {
                    Intent = new Intent()
                    {
                        Name = intent
                    }
                }
            };
        }
    }
}
