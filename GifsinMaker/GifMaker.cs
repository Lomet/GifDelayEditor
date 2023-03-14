using GifMotion;

namespace GifsineMaker;

public class GifMaker : GifLoader
{
    public GifMaker(string inputFile, double maxDelayRatio, double speedUpRatio) : base(inputFile)
    {
        AddReverse();
        NewDelays(new GifSineWave(Count, maxDelayRatio * Average)
        .Absalute(speedUpRatio * Average, (int)Average));
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
    public GifMaker NewDelays(List<int> Delays)
    {
        if (Delays.Count != Count)
            throw new ArgumentOutOfRangeException(nameof(Delays));
        Frames = Frames.Zip(Delays, (frame, delay) =>
        {
            frame.Delay = delay;
            return frame;
        }).ToList();
        return this;
    }
}
