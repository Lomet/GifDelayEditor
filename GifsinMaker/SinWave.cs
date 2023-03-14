public class GifSineWave : List<int>
{
    public GifSineWave(int frameCount, double maxDelay, double min, int value, double startAngle =  - 0.5 * Math.PI) // sine(-0.5 pi) == sine(1.5 pi)
    {
        double period = 2 * Math.PI / frameCount;
        for (int i = 0; i < frameCount; i++)
        {
            int delay = (int)(maxDelay * Math.Sin((i * period) + startAngle));
            Add(Math.Abs(delay) > min ? Math.Abs(delay) : value);          
        }
    }
}
