using GifMotion;
namespace GifsineMaker;

public class GifMaker : GifLoader
{
    public GifMaker(string inputFile) : base(inputFile)
    {
        AddReverse();
    }
    public void SaveGif(string outputFile)
    {
        if (!Frames.Any()) throw new MissingMemberException(nameof(Frames));
        // Create a new GifCreator object with the adjusted delays
        using (GifCreator creator = AnimatedGif.Create(outputFile, 30))
        {
            // Add the frames to the GifCreator object with the adjusted delays
            foreach (var item in Frames)
            {
                creator.AddFrame(item.Frame, item.Delay);
            }
        }
    }
    public GifMaker NewDelays(double maxDelayRatio, double speedUpRatio)
    {
        Frames = Frames.Zip(new GifSineWave(Count, maxDelayRatio * Average, speedUpRatio * Average, (int)Average),
            (frame, delay) =>
        {
            frame.Delay = delay;
            return frame;
        }).ToList();
        return this;
    }
}
