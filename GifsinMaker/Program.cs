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
        if (!File.Exists(args[0]))
        {
            Console.WriteLine($"Input file not found: {args[0]}");
            return;
        }

        new GifMaker(args[0]).NewDelays(maxDelayRatio, speedUpRatio).SaveGif(args[1]);    
    }
}
