using GifsinMaker;
using System.Drawing;

namespace SineWaveGIF
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "sphere.gif";
            string outputFile = $"output_{Math.Abs(DateTime.Now.GetHashCode())}.gif";
            int minDelay = 16;
            int delayValue = 1;
            int maxDelay = 18;

            Run(inputFile, outputFile, minDelay, delayValue, maxDelay);
        }

        private static void Run(string inputFile, string outputFile, int minDelay, int delayValue, int maxDelay)
        {
            var frames = new GifLoader(inputFile).Frames;
            var newFrames = new List<Image>();
            newFrames.AddRange(frames);
            frames.Reverse();
            frames.RemoveAt(0);
            newFrames.AddRange(frames);

            var sineWave = new GifSineWave(newFrames.Count, maxDelay);
            var delays = sineWave.Absalute(minDelay, delayValue);

            new GifMaker(newFrames, delays).SaveGif(outputFile);
        }
    }
}
