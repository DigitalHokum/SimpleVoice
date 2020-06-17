using SimpleVoice.Handlers;
using SimpleVoice.ValueTypes;

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
