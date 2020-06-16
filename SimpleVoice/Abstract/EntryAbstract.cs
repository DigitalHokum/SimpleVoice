using System.Collections.Generic;
using SimpleVoice.Handlers;

namespace SimpleVoice.Abstract
{
    public abstract class EntryAbstract
    {
        private Dictionary<string, RegisterHandler> _handlers;

        public EntryAbstract()
        {
            // Discover handlers
            _handlers = RegisterHandler.Discover();
        }

        protected RegisterHandler GetHandler(string name)
        {
            return _handlers.ContainsKey(name) ? _handlers[name] : null;
        }
    }
}
