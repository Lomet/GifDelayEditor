using GifsineMaker;

namespace SineWaveGIF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                throw new ArgumentException("Usage: program.exe inputfile outputfile maxdelayratio speedupratio");
            }
            if (!double.TryParse(args[2], out double maxDelayRatio) || !double.TryParse(args[3], out double speedUpRatio))
            {
                throw new ArgumentException("Error: maxdelayratio and speedupratio must be valid floating-point numbers.");
            }
            if (!File.Exists(args[0]))
            {
                throw new ArgumentException($"Input file not found: {args[0]}");
            }

            new GifMaker(args[0]).NewDelays(maxDelayRatio, speedUpRatio).SaveGif(args[1]);
        }
    }
}
