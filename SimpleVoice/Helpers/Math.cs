namespace SimpleVoice.Helpers
{
    public class Math
    {
        public static float Lerp(float a, float b, float t)
        {
            return (1f - t) * a + t * b;
        }
    }
}
