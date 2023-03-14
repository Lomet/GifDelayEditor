public class GifSineWave : List<int>
{
    /// <summary>
    /// Creates a sine wave with the specified parameters.
    /// </summary>
    /// <param name="frameCount">The total number of delays needed.</param>
    /// <param name="maxDelay">The maximum value of the sine wave.</param>
    /// <param name="min">The minimum threshold of the sine wave.</param>
    /// <param name="value">The value that will override the minimum threshold.</param>
    /// <param name="startAngle">The starting angle of the sine wave. Default is -0.5 * Math.PI, which is equivalent to sine(-0.5 pi) == sine(1.5 pi).</param>
    public GifSineWave(int frameCount, double maxDelay, double min, int value, double startAngle = -0.5 * Math.PI)
    {
        // Calculate the period of the sine wave.
        double period = 2 * Math.PI / frameCount;

        // Calculate the delay for each frame using the sine wave formula.
        for (int i = 0; i < frameCount; i++)
        {
            int delay = (int)(maxDelay * Math.Sin((i * period) + startAngle));

            // Override the delay if it is below the minimum threshold.
            Add(Math.Abs(delay) > min ? Math.Abs(delay) : value);
        }
    }
}
