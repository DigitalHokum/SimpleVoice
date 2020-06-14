using Amazon.Lambda.Core;

namespace SimpleVoice.Helpers
{
    public class Logger
    {
        public static void Log(string toLog, ILambdaContext context = null)
        {
            if (context != null)
            {
                ILambdaLogger logger = context.Logger;
                logger.Log(toLog);
            }
        }
    }
}