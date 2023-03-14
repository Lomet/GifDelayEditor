using GifsinMaker;

namespace SineWaveGIF
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "sphere.gif";
            string outputFile = $"output_{Math.Abs(DateTime.Now.GetHashCode())}.gif";
            int minDelay = 30;
            int delayValue = 30;
            int maxDelay = 50;

            Run(inputFile, outputFile, minDelay, delayValue, maxDelay);
        }

        private static void Run(string inputFile, string outputFile, int minDelay, int delayValue, int maxDelay)
        {
            var frames = new GifLoader(inputFile);
            frames.AddReverse();
            var sineWave = new GifSineWave(frames.Count, maxDelay);
            var delays = sineWave.Absalute(minDelay, delayValue);
            frames.NewDeleys(delays);
            new GifMaker(frames.Frames).SaveGif(outputFile);
        }
    }
}
