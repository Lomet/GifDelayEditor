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

        new GifMaker(inputFile).NewDelays(maxDelayRatio, speedUpRatio).SaveGif(outputFile);    
    }
}
