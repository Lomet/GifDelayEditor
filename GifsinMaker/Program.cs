using GifsinMaker;

namespace SineWaveGIF
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "sphere.gif";
            string outputFile = $"output_{Math.Abs(DateTime.Now.GetHashCode())}.gif";
            double maxDelayRatio = 2;
            double SpeedUpRatio = 1.5;

            Run(inputFile, outputFile, maxDelayRatio, SpeedUpRatio);
        }

        private static void Run(string inputFile, string outputFile, double maxDelayRatio,double speedUpRatio)
        {
            var frames = new GifLoader(inputFile).AddReverse();
            var delays = new GifSineWave(frames.Count, maxDelayRatio * frames.Average)
                .Absalute(speedUpRatio * frames.Average, (int)frames.Average);
            new GifMaker(frames.Frames).NewDelays(delays).SaveGif(outputFile);
        }
    }
}
