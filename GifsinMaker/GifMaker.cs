using GifMotion;

namespace GifsineMaker
{
    public class GifMaker : GifLoader
    {
        public GifMaker(string inputFile) : base(inputFile)
        {
            AddReverse();
        }

        /// <summary>
        /// Saves the modified GIF to a file.
        /// </summary>
        /// <param name="outputFile">The path to save the output GIF file.</param>
        /// <exception cref="MissingMemberException">Thrown when there are no frames in the GIF.</exception>
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

        /// <summary>
        /// Modifies the delays of the frames in the GIF using a sine wave.
        /// </summary>
        /// <param name="maxDelayRatio">The maximum delay ratio of the sine wave.</param>
        /// <param name="speedUpRatio">The speed up ratio of the sine wave.</param>
        /// <returns>The modified GifMaker object with the new delays.</returns>
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
}
