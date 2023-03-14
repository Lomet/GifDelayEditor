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
            var frames = new GifLoader(inputFile);
            frames.AddReverse();
            var sineWave = new GifSineWave(frames.Count, maxDelayRatio * frames.Average);
            var delays = sineWave.Absalute(speedUpRatio * frames.Average, (int)frames.Average);
            new GifMaker(frames.Frames).NewDeleys(delays).SaveGif(outputFile);
        }
    }
}
