using SimpleVoice.Handlers;
using SimpleVoice.Values;

namespace SimpleVoice.Helpers
{
    public static class SimpleVoice
    {
        public static void Discover()
        {
            HandlerManager.Discover();
            ValueTypeManager.Discover();
        }
    }
}
