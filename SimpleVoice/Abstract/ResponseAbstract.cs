namespace SimpleVoice.Abstract
{
    public abstract class ResponseAbstract
    {
        public string Reprompt;
        public string Speech;

        public abstract void PrepareData();
    }
}
