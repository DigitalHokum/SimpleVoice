using SimpleVoice.Handlers;

namespace SimpleVoice.Abstract
{
    public abstract class EntryAbstract
    {
        public EntryAbstract()
        {
            Helpers.SimpleVoice.Discover();
        }

        protected RegisterHandler GetHandler(string name)
        {
            return HandlerManager.Handlers.ContainsKey(name) ? HandlerManager.Handlers[name] : null;
        }
    }
}
