using GifsineMaker;
namespace SineWaveGIF;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("Usage: program.exe inputfile outputfile maxdelayratio speedupratio");
            return;
        }

        if (!double.TryParse(args[2], out double maxDelayRatio) || !double.TryParse(args[3], out double speedUpRatio))
        {
            Console.WriteLine("Error: maxdelayratio and speedupratio must be valid floating-point numbers.");
            return;
        }

        string inputFile = args[0];
        string outputFile = args[1];

        Run(inputFile, outputFile, maxDelayRatio, speedUpRatio);
    }

    private static void Run(string inputFile, string outputFile, double maxDelayRatio,double speedUpRatio)
    {
        var frames = new GifLoader(inputFile).AddReverse();
        var delays = new GifSineWave(frames.Count, maxDelayRatio * frames.Average)
            .Absalute(speedUpRatio * frames.Average, (int)frames.Average);
        new GifMaker(frames.Frames).NewDelays(delays).SaveGif(outputFile);
    }
}
