using GifMotion;

namespace GifsinMaker
{
    public class GifMaker
    {
        private List<GifFrame> Gifs { get; set; } = new();
        public GifMaker(List<GifFrame> gifs)
        {
            Gifs = gifs;
        }
        public void SaveGif(string outputFile)
        {
            if (!Gifs.Any()) throw new MissingMemberException(nameof(Gifs));
            // Create a new GifCreator object with the adjusted delays
            using (GifCreator creator = AnimatedGif.Create(outputFile, 1))
            {
                // Add the frames to the GifCreator object with the adjusted delays
                foreach (var item in Gifs)
                {
                    creator.AddFrame(item.Frame, item.Delay);
                }
            }
        }
    }
}
