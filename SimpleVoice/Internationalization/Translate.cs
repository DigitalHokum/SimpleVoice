namespace SimpleVoice.Internationalization
{
    public static class Translate
    {

        private static string ToLanguage(string toTranslate, string locale)
        {
            return toTranslate; // Do some sort of magic here!
        }
        
        public static string String(string toTranslate, string locale, params object[] args)
        {
            return System.String.Format(ToLanguage(toTranslate, locale), args);
        }
    }
}
